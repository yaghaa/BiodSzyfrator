using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiodSzyfrator
{
    public partial class Form1 : Form
    {
        private string _myKey = "";
        // klucz zagwiazgkowany !!!!
        // klucz usuwamy z ekranu po wybraniu 'szyfruj' 'deszyfruj'
        //na pulpicie katalog
        //- 2 sensowne pliki o tresci jawnej
        //- plikacja wykonywalna, kod źródłowy
        public Form1()
        {
            InitializeComponent();
            tbKey.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbKey.Text))
            {
                MessageBox.Show("Podaj klucz!");
            }
            else if (IsKeyValid(tbKey.Text) == false)
            {
                
            }
            else
            {
                _myKey = tbKey.Text;
                ClearKey();
                var file = ReadFile();
                var result = Encrypt(file);
                SaveFile(PrepareText(result));
            }
        }

        private void bDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbKey.Text))
            {
                MessageBox.Show("Podaj klucz!");
            }
            else if (IsKeyValid(tbKey.Text) == false)
            {

            }
            else
            {
                _myKey = tbKey.Text;
                ClearKey();
                var file = ReadFile();
                var result = Decrypt(file);
                SaveFile(PrepareText(result));
            }
        }



        #region Decrypt

        private string Decrypt(string file)
        {
            // 1 - Podział na bloki
            string[] blocks = GetBlocks(file);

            // 2 - Przestawienie
            string[] movedBlocks = ClearDisplacements(blocks);

            // 3 - Podstawienie
            string[] unsubstitutedBlocks = UnSubstitute(movedBlocks);
            
            return String.Join("", unsubstitutedBlocks);
        }

        private string[] ClearDisplacements(string[] blocks)
        {
            for (int i = 0; i < blocks.Count(); i++)
            {
                blocks[i] = ClearDisplacement(blocks[i]);
            }

            return blocks;
        }

        private string ClearDisplacement(string block)
        {
            var displacementTable = new char[5, 5];

            displacementTable[2, 0] = block[0];
            displacementTable[2, 1]= block[1];
            displacementTable[1, 2]= block[2];
            displacementTable[2, 2]= block[3];
            displacementTable[3, 2]= block[4];
            displacementTable[2, 3]= block[5];
            displacementTable[1, 3]= block[6];
            displacementTable[3, 3]= block[7];
            displacementTable[0, 4]= block[8];
            displacementTable[1, 4]= block[9];
            displacementTable[2, 4]= block[10];
            displacementTable[3, 4]= block[11];
            displacementTable[4, 4] = block[12];

            var newBlock = displacementTable[0, 4].ToString() +
                           displacementTable[1, 2].ToString() +
                           displacementTable[1, 3].ToString() +
                           displacementTable[1, 4].ToString() +
                           displacementTable[2, 0].ToString() +
                           displacementTable[2, 1].ToString() +
                           displacementTable[2, 2].ToString() +
                           displacementTable[2, 3].ToString() +
                           displacementTable[2, 4].ToString() +
                           displacementTable[3, 2].ToString() +
                           displacementTable[3, 3].ToString() +
                           displacementTable[3, 4].ToString() +
                           displacementTable[4, 4].ToString();
            return newBlock;
        }

        private string[] UnSubstitute(string[] blocks)
        {
            var moveIndex = GetMoveIndex();
            for (int i = 0; i < blocks.Count(); i++)
            {
                var newBlock = "";
                for (int j = 0; j < blocks[i].Count(); j++)
                {
                    var newChar = GetOldChar(blocks[i][j], moveIndex + j);
                    newBlock += newChar;
                }
                blocks[i] = newBlock;
            }

            return blocks;
        }

        private char GetOldChar(char c, int i)
        {
            var number = (int)c;
            number -= i;
            return (char)number;
        }

        #endregion


        #region Encrypt

        private string Encrypt(string file)
        {
            // 1 - Podział na bloki
            string[] blocks = GetBlocks(file);

            // 2 - Podstawienie
            string[] substitutedBlocks = Substitute(blocks);

            // 3 - Przestawienie
            string[] movedBlocks = Displacement(substitutedBlocks);

            return String.Join("", movedBlocks);
        }

        private string[] Displacement(string[] substitutedBlocks)
        {
            for (int i = 0; i < substitutedBlocks.Count(); i++)
            {
                substitutedBlocks[i] = GetDisplacementBlock(substitutedBlocks[i]);
            }

            return substitutedBlocks;
        }

        private string GetDisplacementBlock(string substitutedBlock)
        {
            var displacementTable = new char[5, 5];

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        if (PyramidFieldReserved(i,j) == false)
            //        {
            //            displacementTable[i][j] =
            //        }
            //        else
            //        {
            //            displacementTable[i][j] = null;
            //        }
            //    }
            //}

            displacementTable[0, 4] = substitutedBlock[0];
            displacementTable[1, 2] = substitutedBlock[1];
            displacementTable[1, 3] = substitutedBlock[2];
            displacementTable[1, 4] = substitutedBlock[3];
            displacementTable[2, 0] = substitutedBlock[4];
            displacementTable[2, 1] = substitutedBlock[5];
            displacementTable[2, 2] = substitutedBlock[6];
            displacementTable[2, 3] = substitutedBlock[7];
            displacementTable[2, 4] = substitutedBlock[8];
            displacementTable[3, 2] = substitutedBlock[9];
            displacementTable[3, 3] = substitutedBlock[10];
            displacementTable[3, 4] = substitutedBlock[11];
            displacementTable[4, 4] = substitutedBlock[12];

            var newBlock = displacementTable[2, 0].ToString() +
                           displacementTable[2, 1].ToString() +
                           displacementTable[1, 2].ToString() +
                           displacementTable[2, 2].ToString() +
                           displacementTable[3, 2].ToString() +
                           displacementTable[2, 3].ToString() +
                           displacementTable[1, 3].ToString() +
                           displacementTable[3, 3].ToString() +
                           displacementTable[0, 4].ToString() +
                           displacementTable[1, 4].ToString() +
                           displacementTable[2, 4].ToString() +
                           displacementTable[3, 4].ToString() +
                           displacementTable[4, 4].ToString();
            return newBlock;
        }

        private bool PyramidFieldReserved(int i, int j)
        {
            if ((i == 1 && j == 1) || (i == 1 && j == 1))
            {
                return true;
            }
            return false;
        }

        private string[] Substitute(string[] blocks)
        {
            var moveIndex = GetMoveIndex();
            for (int i = 0; i < blocks.Count(); i++)
            {
                var newBlock = "";
                for (int j = 0; j < blocks[i].Count(); j++)
                {
                    var newChar = GetNewChar(blocks[i][j], moveIndex + j);
                    newBlock += newChar;
                }
                blocks[i] = newBlock;
            }

            return blocks;
        }

        private char GetNewChar(char c, int i)
        {
            var number = (int)c;
            number += i;
            return (char)number;
        }

        private int GetMoveIndex()
        {
            var count = _myKey.Count(Char.IsDigit);
            count += _myKey.Where(Char.IsDigit).Sum(p => Convert.ToInt32(p.ToString()));
            return count;
        }

       
        
        #endregion


        #region FileOperations
        private string ReadFile()
        {
            return String.Join(((char)13).ToString(), System.IO.File.ReadAllLines(tbSourceFile.Text, Encoding.GetEncoding("iso-8859-1")));
        }

        private void SaveFile(string text)
        {
            System.IO.File.WriteAllText(tbOutcome.Text, text, Encoding.GetEncoding("iso-8859-1"));
        }

        private void bChooseBaseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "test";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbSourceFile.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void bOutput_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "test";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbOutcome.Text = openFileDialog2.FileName.ToString();
            }
        }

        #endregion

        #region Helpers
        private void bInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klucz szyfrujący musi:"
                            + Environment.NewLine + "• zawierać co najmniej 10"
                            + Environment.NewLine + "• zawierać co najmniej 4 cyfry"
                            + Environment.NewLine + "• zawierać co najmniej 4 litery"
                            + Environment.NewLine + "• zawierać co najmniej 2 znaki specjalne"
                            + Environment.NewLine
                            + Environment.NewLine + "Gdy nie wybierzesz ścieżki docelowej Szyfrogram zapisze zaszyfrowany plik"
                            + Environment.NewLine + " w tym samym katalogu co plik źródłowy, pod nazwą 'encrypted.txt'"
            );
        }

        private string PrepareText(string toString)
        {
            return toString;
        }


        private bool IsKeyValid(string myKey)
        {
            if (myKey.Length < 10)
            {
                MessageBox.Show("Klucz musi posiadać przynajmniej 10 znaków. Popraw klucz.");
                return false;
            }
            var numbersInKey = myKey.Where(x => (int)x >= 48 && (int)x <= 57).ToList();
            if (numbersInKey.Count < 4)
            {
                MessageBox.Show("Klucz musi posiadać przynajmniej 4 cyfry. Popraw klucz.");
                return false;
            }
            var letersInKey = myKey.Where(x => ((int)x >= 65 && (int)x <= 90) || ((int)x >= 97 && (int)x <= 122)).ToList();
            if (letersInKey.Count < 4)
            {
                MessageBox.Show("Klucz musi posiadać przynajmniej 4 litery. Popraw klucz.");
                return false;
            }
            var specialInKey = myKey.Where(x => ((int)x >= 33 && (int)x <= 47)).ToList();
            if (specialInKey.Count < 2)
            {
                MessageBox.Show("Klucz musi posiadać przynajmniej 2 znaki specjalne. Popraw klucz.");
                return false;
            }
            return true;
        }

        private string[] GetBlocks(string file)
        {
            var additionalRow = 0;
            if (file.Length % 13 != 0)
            {
                additionalRow = 1;
            }
            var blockCount = (file.Length / 13 + additionalRow);
            string[] blocks = new string[blockCount];
            var numberInBlock = 0;
            var blockNumber = 0;
            var block = "";

            for (int j = 0; j < file.Count(); j++)
            {
                if (numberInBlock < 13)
                {
                    block = block + file[j];
                    if (j == file.Count() - 1)
                    {
                        for (int i = numberInBlock; i < 13; i++)
                        {
                            block = block + (char)32;
                        }
                        blocks[blockNumber] = block;
                        break;
                    }
                    numberInBlock++;
                }
                else
                {
                    blocks[blockNumber] = block;
                    block = "";
                    block = block + file[j];

                    blockNumber++;
                    numberInBlock = 1;
                }
            }
            return blocks;
        }

        private void ClearKey()
        {
            tbKey.Text = "";
        }
        #endregion

    }
}