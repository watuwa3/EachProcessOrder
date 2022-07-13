using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms;

    public class CsvUtil
    {

        /// <summary>
        /// CSV��ǂݍ���DataTable�Ƃ��ĕԂ�
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="isHeader"></param>
        /// <param name="limit"></param>
        /// <param name="enccodeName"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public DataTable CsvRead(string filename, bool isHeader, long limit = long.MaxValue, string encodeName = "shift-jis", string delimiter = "")
        {
            

            limit += (isHeader == true && limit < long.MaxValue) ? 1 : 0;
            long count = 0;


            var enc = Encoding.GetEncoding(encodeName);
            delimiter = (delimiter == "") ? GetDelimiter(filename, enc) : delimiter;

            DataTable dt = new DataTable();

            using (TextFieldParser parser = new TextFieldParser(filename, enc) { TextFieldType = FieldType.Delimited })
            {
                parser.Delimiters = new string[] { delimiter };

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (count++ == 0)
                    {
                        //�w�b�_������ꍇ�A1�s�ڂ̃f�[�^�ŗ��ǉ�
                        dt.Columns.AddRange(fields.Select(i => (isHeader) ? new DataColumn(i) : new DataColumn()).ToArray());
                        if (isHeader)
                        {
                            continue;
                        }
                    }

                    if (fields.Length > dt.Columns.Count)
                    {
                        dt.Columns.AddRange(Enumerable.Range(0, fields.Length - dt.Columns.Count).Select(i => new DataColumn()).ToArray());
                    }

                    if (count > limit)
                    {
                        break;
                    }

                    DataRow dr = dt.NewRow();
                    Enumerable.Range(0, fields.Length).Select(i => dr[i] = fields[i]).ToArray();
                    dt.Rows.Add(dr);
                }
            }

            return dt;

        }

        /// <summary>
        /// DataTable�̓��e��CSV�`���Ńt�@�C���ɏo�͂���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filename"></param>
        /// <param name="writeHeader"></param>
        /// <param name="delimiter"></param>
        /// <param name="encodeName"></param>
        /// <param name="isAppend"></param>
        public void CsvWrite(DataTable dt, string filename, bool writeHeader, string delimiter = ",", string encodeName = "shift-jis", bool isAppend = false)
        {
            bool header = (writeHeader && (isAppend == false || (isAppend == true && File.Exists(filename) == false)));
            //�������ރt�@�C�����J��
            using (StreamWriter sw = new StreamWriter(filename, isAppend, Encoding.GetEncoding(encodeName)))
            {
                //�w�b�_����������
                if (header)
                {
                    string[] headers = dt.Columns.Cast<DataColumn>().Select(i => enclose_ifneed(i.ColumnName)).ToArray();
                    sw.WriteLine(String.Join(delimiter, headers));
                }

                //���R�[�h����������
                foreach (DataRow dr in dt.Rows)
                {
                    string[] fields = Enumerable.Range(0, dt.Columns.Count).Select(i => enclose_ifneed(dr[i].ToString())).ToArray();
                    sw.WriteLine(String.Join(delimiter, fields));
                }
            }

            return;

            /// �K�v�Ȃ�΁A��������_�u���N�H�[�g�ň͂�
            string enclose_ifneed(string p_field)
            {
                //�_�u���N�H�[�g�Ŋ���K�v�����邩���m�F
                if (p_field.Contains('"') || p_field.Contains(',') || p_field.Contains('\r') || p_field.Contains('\n') ||
                     p_field.StartsWith(" ") || p_field.StartsWith("\t") || p_field.EndsWith(" ") || p_field.EndsWith("\t"))
                {
                    //�_�u���N�H�[�g���܂܂�Ă�����Q�d�˂āA�O��Ƀ_�u���N�H�[�g��t��
                    return (p_field.Contains('"')) ? ("\"" + p_field.Replace("\"", "\"\"") + "\"") : ("\"" + p_field + "\"");
                }
                else
                {
                    //�����������̂܂ܕԂ�
                    return p_field;
                }
            }

        }

        /// <summary>
        /// ��؂蕶���̎�������
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="encodeName"></param>
        /// <returns></returns>
        public string GetDelimiter(string filename, Encoding encodeName)
        {
            using (StreamReader sr = new StreamReader(filename, encodeName))
            {
                string line = sr.ReadLine();
                return (line.Split(',').Length > line.Split('\t').Length) ? "," : "\t";
            }
        }
    }
