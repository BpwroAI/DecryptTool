using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecryptTool
{
    public partial class Form1 : Form
    {

        private string[] files = new string[0];
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
        }

        //�t�@�C���̓ǂݍ���
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // �擾�����t�@�C���p�X��args[]�ɑ�������
            string formattedFiles = string.Join(" ", files.Select(f => $"\"{f}\""));
            Environment.SetEnvironmentVariable("ArgsPlaceholder", string.Join(" ", files));
            int fileCount = files.Length;
            if (fileCount > 0)
            {
                label1.Text = $"�ǂݍ��܂ꂽ�t�@�C����: {fileCount}";
                this.Text = $"DecryptTool - �Ǎ��݃t�@�C����: {fileCount}";
            }
        }

        //XOR
        private void button1_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                MessageBox.Show("�t�@�C�����h���b�O���h���b�v���Ă��������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] key = ParseKey(textBox1.Text);
            if (key == null || key.Length == 0)
            {
                MessageBox.Show("�L�[�̌`�����s���ł��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int offset = ParseNumber(textBox2.Text);
            int range = radioButton2.Checked ? ParseNumber(textBox3.Text) : 0;
            int endAddress = radioButton3.Checked ? ParseNumber(textBox4.Text) : 0;

            string outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output-" + DateTime.Now.ToString("yyyyMMddHHmm"));
            Directory.CreateDirectory(outputDir);

            foreach (var file in files)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(file);
                    if (offset >= data.Length)
                    {
                        MessageBox.Show($"�t�@�C�� {file} �̃I�t�Z�b�g���f�[�^�T�C�Y�𒴂��Ă��܂��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    byte[] result = ApplyXOR(data, key, offset, range, endAddress);
                    string outputPath = Path.Combine(outputDir, Path.GetFileName(file));
                    File.WriteAllBytes(outputPath, result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�t�@�C�� {file} �̏������ɃG���[���������܂����B\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("�������������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            files = new string[0];
            label1.Text = "�f�R�[�h�������t�@�C���������Ƀh���b�O�A���h�h���b�v���Ă��������B";
            this.Text = "DecryptTool";
        }

        private byte[] ParseKey(string keyText)
        {
            if (string.IsNullOrWhiteSpace(keyText)) return null;

            if (keyText.StartsWith("0x"))
            {
                keyText = keyText.Substring(2);
                try
                {
                    return Enumerable.Range(0, keyText.Length / 2)
                        .Select(i => Convert.ToByte(keyText.Substring(i * 2, 2), 16))
                        .ToArray();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return Encoding.UTF8.GetBytes(keyText);
            }
        }

        private int ParseNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            try
            {
                if (text.StartsWith("0x"))
                {
                    return Convert.ToInt32(text, 16);
                }
                return int.TryParse(text, out int result) ? result : 0;
            }
            catch
            {
                return 0;
            }
        }

        private byte[] ApplyXOR(byte[] data, byte[] key, int offset, int range, int endAddress)
        {
            int length = data.Length;
            if (radioButton1.Checked)
            {
                offset = 0;
                length = data.Length;
            }
            else if (radioButton2.Checked)
            {
                length = Math.Min(data.Length, offset + range);
            }
            else if (radioButton3.Checked)
            {
                length = Math.Min(data.Length, endAddress);
            }

            length = Math.Max(offset, Math.Min(length, data.Length));

            byte[] result = new byte[data.Length];
            Array.Copy(data, result, data.Length);

            for (int i = offset; i <= length; i++)
            {
                result[i] = (byte)(data[i] ^ key[i % key.Length]);
            }
            return result;
        }

        //�o�C�i���u������
        private void button2_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                MessageBox.Show("�t�@�C�����h���b�O���h���b�v���Ă��������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int offset = ParseNumber(textBox5.Text);
            int range = radioButton4.Checked ? ParseNumber(textBox6.Text) : 0;
            int endAddress = radioButton5.Checked ? ParseNumber(textBox7.Text) : 0;

            string outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output-" + DateTime.Now.ToString("yyyyMMddHHmm"));
            Directory.CreateDirectory(outputDir);

            foreach (var file in files)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(file);
                    if (offset >= data.Length)
                    {
                        MessageBox.Show($"�t�@�C�� {file} �̃I�t�Z�b�g���f�[�^�T�C�Y�𒴂��Ă��܂��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    string hexInput = textBox8.Text.Replace(" ", "");
                    if (hexInput.Length % 2 != 0)
                    {
                        MessageBox.Show("16�i���f�[�^�̒������s���ł��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    byte[] newData = Enumerable.Range(0, hexInput.Length / 2).Select(i => Convert.ToByte(hexInput.Substring(i * 2, 2), 16)).ToArray();

                    int length; // ���������͈͂�ݒ肷��ϐ�

                    // ���W�I�{�^���̑I���ɉ���������
                    if (radioButton4.Checked) // range���g�p����ꍇ
                    {
                        length = Math.Min(range, data.Length - offset); // �ő�ł��t�@�C���̏I�[�𒴂��Ȃ�
                    }
                    else if (radioButton5.Checked) // endAddress���g�p����ꍇ
                    {
                        if (endAddress > data.Length)
                        {
                            MessageBox.Show("endAddress���t�@�C���T�C�Y�𒴂��Ă��܂��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        length = endAddress - offset; // offset ���� endAddress �܂�
                    }
                    else
                    {
                        MessageBox.Show("�͈͂��w�肳��Ă��܂���B���W�I�{�^����I�����Ă��������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // �͈̓`�F�b�N
                    if (offset + length > data.Length)
                    {
                        MessageBox.Show("�w�肳�ꂽ�͈͂��t�@�C���T�C�Y�𒴂��Ă��܂��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // �u����������
                    Array.Copy(newData, 0, data, offset, Math.Min(newData.Length, length));

                    // �o�̓t�@�C���̕ۑ�
                    string outputPath = Path.Combine(outputDir, Path.GetFileName(file));
                    File.WriteAllBytes(outputPath, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�t�@�C�� {file} �̏������ɃG���[���������܂����B\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("�������������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            files = new string[0];
            label1.Text = "�f�R�[�h�������t�@�C���������Ƀh���b�O�A���h�h���b�v���Ă��������B";
            this.Text = "DecryptTool";
        }
    }
}
