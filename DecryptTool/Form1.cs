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
            radioButton6.Checked = true;
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
            if (string.IsNullOrWhiteSpace(keyText))
                return null;

            try
            {
                if (keyText.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    keyText = keyText.Substring(2).Replace(" ", ""); // "0x" を削除しスペース除去
                }

                // スペース区切りの 16 進数対応
                if (keyText.All(c => "0123456789ABCDEFabcdef".Contains(c)))
                {
                    return Enumerable.Range(0, keyText.Length / 2)
                        .Select(i => Convert.ToByte(keyText.Substring(i * 2, 2), 16))
                        .ToArray();
                }

                // UTF-8 文字列キーとして処理
                return Encoding.UTF8.GetBytes(keyText);
            }
            catch
            {
                return null;
            }
        }

        private int ParseNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            try
            {
                // スペースを除去
                text = text.Replace(" ", "");

                // 16進数の場合（0xがある or すべて16進数文字）
                if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    text = text.Substring(2); // "0x" を削除
                }

                // 16進数として解析
                if (uint.TryParse(text, System.Globalization.NumberStyles.HexNumber, null, out uint hexValue))
                {
                    return unchecked((int)hexValue);
                }

                // 10進数として解析
                if (int.TryParse(text, out int decimalValue))
                {
                    return decimalValue;
                }
            }
            catch
            {
                // 例外発生時はデフォルト値を返す
            }
            return 0;
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
            length = Math.Min(length + 1, data.Length);

            byte[] result = new byte[data.Length];
            Array.Copy(data, result, data.Length);

            for (int i = offset; i < length; i++)
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

        //バイナリカット
        private void button3_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                MessageBox.Show("ファイルをドラッグ＆ドロップしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int offset = ParseNumber(textBox9.Text);
            int range = radioButton6.Checked ? ParseNumber(textBox10.Text) : 0;
            int endAddress = radioButton7.Checked ? ParseNumber(textBox7.Text) : 0;

            string outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output-" + DateTime.Now.ToString("yyyyMMddHHmm"));
            Directory.CreateDirectory(outputDir);

            foreach (var file in files)
            {
                if (radioButton6.Checked)
                {
                    try
                    {
                        byte[] data = File.ReadAllBytes(file);

                        // バイト数がファイルサイズを超えていないか確認
                        if (offset < 0 || range < 0 || offset + range > data.Length)
                        {
                            Console.WriteLine("削除する範囲が無効です。");
                            return;
                        }

                        // 削除後のデータを作成
                        byte[] newData = new byte[data.Length - range];
                        Array.Copy(data, 0, newData, 0, offset); // オフセット前のデータをコピー
                        Array.Copy(data, offset + range, newData, offset, data.Length - (offset + range)); // 削除後のデータをコピー

                        // 新しいファイルを書き込む
                        string outputPath = Path.Combine(outputDir, Path.GetFileName(file));
                        File.WriteAllBytes(outputPath, newData);
                        Console.WriteLine("処理が完了しました。");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ファイル {file} の処理中にエラーが発生しました。\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (radioButton7.Checked)
                {
                    try
                    {
                        byte[] data = File.ReadAllBytes(file);
                        byte[] pattern = ParseKey(textBox11.Text);
                        int skip;

                        // TextBoxに入力された内容をint型に変換
                        if (!int.TryParse(textBox12.Text, out skip))
                        {
                            // 変換失敗
                            MessageBox.Show("無効な入力です。数値を入力してください。");
                            return;
                        }

                        long position = FindPatternPosition(data, pattern, skip);
                        if (position >= 0)
                        {
                            Console.WriteLine($"パターンの位置: {position}");
                            byte[] newData = new byte[data.Length - position];
                            Array.Copy(data, position, newData, 0, newData.Length);

                            // 新しいファイルを書き込む
                            string outputPath = Path.Combine(outputDir, Path.GetFileName(file));
                            File.WriteAllBytes(outputPath, newData);
                            Console.WriteLine("処理が完了しました。");
                        }
                        else
                        {
                            Console.WriteLine("指定したパターンが見つかりませんでした。");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ファイル {file} の処理中にエラーが発生しました。\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            files = new string[0];
            label1.Text = "デコードしたいファイルをここにドラッグアンドドロップしてください。";
            this.Text = "DecryptTool";
        }
        static long FindPatternPosition(byte[] data, byte[] pattern, int skipnum)
        {
            int matchCount = 0;
            for (long i = 0; i <= data.Length - pattern.Length; i++)
            {
                bool isMatch = true;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (data[i + j] != pattern[j])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    if (matchCount == skipnum)
                    {
                        return i; // スキップ回数を考慮した最終位置を返す
                    }
                    matchCount++;
                }
            }
            return -1;
        }
        //static long FindPatternPosition(byte[] data, byte[] pattern, int skipnum)
        //{
        //    for (long i = 0; i <= data.Length - pattern.Length; i++)
        //    {
        //        bool isMatch = true;

        //        for (int j = 0; j < pattern.Length; j++)
        //        {
        //            if (data[i + j] != pattern[j])
        //            {
        //                isMatch = false;
        //                break;
        //            }
        //        }

        //        if (isMatch)
        //        {
        //            if (skipnum == 0)
        //            {
        //                return i;
        //            }
        //            skipnum--;
        //        }
        //    }
        //    return -1;
        //}



    }
}
