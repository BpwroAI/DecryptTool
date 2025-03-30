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

        //ファイルの読み込み
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
            // 取得したファイルパスをargs[]に代入する例
            string formattedFiles = string.Join(" ", files.Select(f => $"\"{f}\""));
            Environment.SetEnvironmentVariable("ArgsPlaceholder", string.Join(" ", files));
            int fileCount = files.Length;
            if (fileCount > 0)
            {
                label1.Text = $"読み込まれたファイル数: {fileCount}";
                this.Text = $"DecryptTool - 読込みファイル数: {fileCount}";
            }
        }

        //XOR
        private void button1_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                MessageBox.Show("ファイルをドラッグ＆ドロップしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] key = ParseKey(textBox1.Text);
            if (key == null || key.Length == 0)
            {
                MessageBox.Show("キーの形式が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"ファイル {file} のオフセットがデータサイズを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    byte[] result = ApplyXOR(data, key, offset, range, endAddress);
                    string outputPath = Path.Combine(outputDir, Path.GetFileName(file));
                    File.WriteAllBytes(outputPath, result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ファイル {file} の処理中にエラーが発生しました。\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            files = new string[0];
            label1.Text = "デコードしたいファイルをここにドラッグアンドドロップしてください。";
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

        //バイナリ置き換え
        private void button2_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                MessageBox.Show("ファイルをドラッグ＆ドロップしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"ファイル {file} のオフセットがデータサイズを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    string hexInput = textBox8.Text.Replace(" ", "");
                    if (hexInput.Length % 2 != 0)
                    {
                        MessageBox.Show("16進数データの長さが不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    byte[] newData = Enumerable.Range(0, hexInput.Length / 2).Select(i => Convert.ToByte(hexInput.Substring(i * 2, 2), 16)).ToArray();

                    int length; // 書き換え範囲を設定する変数

                    // ラジオボタンの選択に応じた処理
                    if (radioButton4.Checked) // rangeを使用する場合
                    {
                        length = Math.Min(range, data.Length - offset); // 最大でもファイルの終端を超えない
                    }
                    else if (radioButton5.Checked) // endAddressを使用する場合
                    {
                        if (endAddress > data.Length)
                        {
                            MessageBox.Show("endAddressがファイルサイズを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        length = endAddress - offset; // offset から endAddress まで
                    }
                    else
                    {
                        MessageBox.Show("範囲が指定されていません。ラジオボタンを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 範囲チェック
                    if (offset + length > data.Length)
                    {
                        MessageBox.Show("指定された範囲がファイルサイズを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 置き換え処理
                    Array.Copy(newData, 0, data, offset, Math.Min(newData.Length, length));

                    // 出力ファイルの保存
                    string outputPath = Path.Combine(outputDir, Path.GetFileName(file));
                    File.WriteAllBytes(outputPath, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ファイル {file} の処理中にエラーが発生しました。\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            files = new string[0];
            label1.Text = "デコードしたいファイルをここにドラッグアンドドロップしてください。";
            this.Text = "DecryptTool";
        }
    }
}
