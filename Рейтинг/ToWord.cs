using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Рейтинг.Properties;
using System.Windows.Forms;
using Рейтинг.ProgClass;
using System.ComponentModel;

namespace Рейтинг
{
    class ToWord
    {

        public  static void StartWordOtchot(Group g,Predmet p,Lesson l, BindingList<Student> tmpclass)
        {
            int count = tmpclass.Count;

            
            try
            {
                File.WriteAllBytes("Полесский государственный университет.docx", Resources.Полесский_государственный_университет);
               
            }
            catch (Exception)
            {

                MessageBox.Show("Закройте прошлый документ!!!");

            }
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Open(Environment.CurrentDirectory + @"\Полесский государственный университет.docx",ReadOnly:false, Visible: true);
            try
            {
                Word.Range r = doc.Bookmarks["fac"].Range;
                r.Text = g.Fac;
                r.Font.Bold = 0;
                r.Select();
                r = doc.Bookmarks["spec"].Range;
                r.Text = g.Spec;
                r.Font.Bold = 0;
                r.Select();
                r = doc.Bookmarks["kurs"].Range;
                r.Text = g.Curs.ToString();
                r.Font.Bold = 0;
                r.Select();
                r = doc.Bookmarks["group"].Range;
                r.Text = g.ToString();
                r.Font.Bold = 0;
                r.Select();
                r = doc.Bookmarks["lesson"].Range;
                r.Text = p.Name;
                r.Font.Bold = 0;
                r.Select();
                r = doc.Bookmarks["prepod"].Range;
                r.Text = Server.myInfo.FIO;
                r.Font.Bold = 0;
                r.Select();
                r = doc.Bookmarks["data"].Range;
                r.Text = DateTime.Today.ToLongDateString();
                r.Font.Bold = 0;
                r.Select();

                //формирование таблицы
                r = doc.Bookmarks["tabel"].Range;
                Object Def = Word.WdDefaultTableBehavior.wdWord8TableBehavior;
                if (l.Zanatie.Count != 0)
                {
                    Object Def1 = Word.WdAutoFitBehavior.wdAutoFitWindow;
                    doc.Tables.Add(r, 2 + count, 4 + l.Zanatie.Count, Def, Def1);

                    Word.Table tabl = doc.Tables[1];
                    tabl.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    tabl.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    tabl.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    //ширина колонок
                    tabl.Cell(1, 1).Column.SetWidth(23f, Word.WdRulerStyle.wdAdjustNone);
                    tabl.Cell(1, 2).Column.SetWidth(170f, Word.WdRulerStyle.wdAdjustNone);
                    tabl.Cell(1, tabl.Columns.Count - 1).Column.SetWidth(50f, Word.WdRulerStyle.wdAdjustNone);
                    tabl.Cell(1, tabl.Columns.Count).Column.SetWidth(80f, Word.WdRulerStyle.wdAdjustNone);
                    tabl.Rows[2].SetHeight(120f, Word.WdRowHeightRule.wdRowHeightAuto);



                    //шапка
                    {
                        tabl.Cell(1, 1).Merge(tabl.Cell(2, 1));
                        tabl.Cell(1, 2).Merge(tabl.Cell(2, 2));
                        tabl.Cell(1, tabl.Columns.Count - 1).Merge(tabl.Cell(2, tabl.Columns.Count - 1));
                        tabl.Cell(1, tabl.Columns.Count).Merge(tabl.Cell(2, tabl.Columns.Count));
                        tabl.Cell(1, 3).Merge(tabl.Cell(1, tabl.Columns.Count - 2));

                        tabl.Cell(1, 1).Range.Text = "№ п/ п";
                        tabl.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        tabl.Cell(1, 2).Range.Text = "Фамилия, Имя, Отчество студента";
                        tabl.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        tabl.Cell(1, 3).Range.Text = "Оценка по формам текущего контроля";
                        tabl.Cell(1, 4).Range.Text = "Оценка текущей успеваемости";
                        tabl.Cell(1, 4).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
                        tabl.Cell(1, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                        tabl.Cell(1, 5).Range.Text = "Подпись преподавателя";
                        tabl.Cell(1, 5).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        tabl.Cell(1, 5).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;
                    }



                    for (int i = 1; i <= count; i++)
                    {
                        tabl.Cell(2 + i, 1).Range.Text = i.ToString();
                    }
                    for (int i = 1; i <= count; i++)
                    {
                        tabl.Cell(2 + i, 2).Range.Text = tmpclass[i - 1].FIO;

                    }
                    for (int i = 0; i < l.Zanatie.Count; i++)
                    {
                        tabl.Cell(2, 3 + i).Range.Text = l.Zanatie[i].Name;
                        tabl.Cell(2, 3 + i).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        tabl.Cell(2, 3 + i).Range.Orientation = Word.WdTextOrientation.wdTextOrientationUpward;

                    }

                    foreach (Zanatie item in l.Zanatie)
                    {
                        foreach (var itemDost in item.Dost)
                        {
                            tabl.Cell(3 + tmpclass.IndexOf(tmpclass.Where(x => x.Id == itemDost.Student_id).ToList()[0]), 3 + l.Zanatie.IndexOf(item)).Range.Text = itemDost.Ocenka.ToString();
                        }

                    }

                    for (int i = 0; i < count; i++)
                    {
                        int kol = 0;
                        double srball = 0;
                        for (int k = 0; k < l.Zanatie.Count; k++)
                        {
                            int temp;
                            if (tabl.Cell(3 + i, 3 + k).Range.Text.Length != 0)
                            {
                                string m = tabl.Cell(3 + i, 3 + k).Range.Text.Remove(tabl.Cell(3 + i, 3 + k).Range.Text.IndexOf('\r'));

                                if (Int32.TryParse(m, out temp))
                                {
                                    kol++;
                                    srball += temp;
                                }
                            }
                        }
                        if (kol > 0) tabl.Cell(3 + i, 3 + l.Zanatie.Count).Range.Text = (srball / kol).ToString("F1");


                    }
                    tabl.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);





                }
                else {
                    MessageBox.Show("Заполните таблицу ");
                }

                //показать программу
                app.Visible = true;
            } catch (Exception) {
                doc.Close();
                
            }
            try

            {

            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

            }
        }
    }
}
