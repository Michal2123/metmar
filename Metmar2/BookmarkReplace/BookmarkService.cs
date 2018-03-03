using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using System.Linq;
using System.Data;
using System.ComponentModel;
using Metmar2.Models;
using System.Diagnostics;

namespace Metmar2.BookmarkReplace
{

    public class BookmarkService
    {

        public void GenerateDoc(KlientModel klient, BindingList<ItemModel> list, int nrfaktury)
        {
            int lp = 1;
            string bmName;

            string source = @"C:\temp\umowa1.docx";
            string destinaton = source.Replace("umowa1", "umowa_" + Guid.NewGuid().ToString());

            File.Copy(source, destinaton);

            using (WordprocessingDocument document = WordprocessingDocument.Open(destinaton, true))
            {

                var mainPart = document.MainDocumentPart;
                bmName = "Tabela";
                var res = from bm in mainPart.Document.Body.Descendants<BookmarkStart>()
                          where bm.Name == bmName
                          select bm;
                var bookmark = res.SingleOrDefault();
                if (bookmark != null)
                {
                    var parent = bookmark.Parent; 


                    Run run = new Run(new RunProperties(new Bold()));
                    Paragraph newParagraph = new Paragraph(run);

                    parent.InsertBeforeSelf(newParagraph);
                    parent.Remove();

                    Table table = new Table();
                    TableProperties props = new TableProperties(
                        new TableStyle() { Val = "TableGrid" },
                        new TableWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto },
                        new TableBorders(
                            new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                        ),
                        new TableGrid(
                            new GridColumn() { Width = new StringValue("500") },
                            new GridColumn() { Width = new StringValue("4500") },
                            new GridColumn() { Width = new StringValue("800") },
                            new GridColumn() { Width = new StringValue("1000") },
                            new GridColumn() { Width = new StringValue("700") },
                            new GridColumn() { Width = new StringValue("900") },
                            new GridColumn() { Width = new StringValue("900") },

                    new TableRow(
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Lp."))
                            )),
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Nazwa"))
                            )),
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Ilość"))
                            )),
                         new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Tryb najmu")))),
                          new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Czas")))),
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Kaucja")))),
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Cena"))))
                        )));
                    table.AppendChild(props);

                    foreach (ItemModel item in list)
                    {
                        string typStawkiSlownie = string.Empty;
                        if (item.TypStawki == TypStawki.Dobowa)
                        {
                            typStawkiSlownie = "Doba";
                        }
                        else if (item.TypStawki == TypStawki.Godzinowa)
                        {
                            typStawkiSlownie = "Godzinowa";
                        }
                        else
                        {
                            typStawkiSlownie = "Cena";
                        }

                        table.Append(new TableRow(
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(lp.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.DisplayedNazwa))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.Ilosc.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(typStawkiSlownie))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.IloscCzas.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.Kaucja.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.SumaZaPrzedmiot.ToString())))))

                                    ));

                        lp++;

                    }
                    newParagraph.InsertBeforeSelf(table);

                    bmName = "Imie";
                    bookmark = res.Single();
                    parent = bookmark.Parent;
                    var paragraph =
                        new Paragraph(new Run(new Text(string.Empty)),
                            new Paragraph(
                                new Run(new Text($"Najemca: {klient.Imie} {klient.Nazwisko} "))),
                            new Paragraph(
                                new Run(new Text($"Adres: { klient.Adres }"))),
                            new Paragraph(
                                new Run(new Text($"Pesel: {klient.Pesel} Telefon: {klient.Telefon}")))
                            );
                    parent.InsertBeforeSelf(paragraph);
                    parent.Remove();

                    bmName = "NrFaktura";
                    bookmark = res.Single();
                    parent = bookmark.Parent;
                    paragraph =
                        new Paragraph(
                            new Run(new Text($"Nr faktury: {nrfaktury.ToString()}")));
                    parent.InsertBeforeSelf(paragraph);
                    parent.Remove();

                    bmName = "Data";
                    bookmark = res.Single();
                    parent = bookmark.Parent;
                    paragraph =
                        new Paragraph(
                            new Run(
                                new Text($"Data: {DateTime.Now.ToString()}")));
                    parent.InsertBeforeSelf(paragraph);
                    parent.Remove();

                    bmName = "DataPodpis";
                    bookmark = res.Single();
                    parent = bookmark.Parent;
                    paragraph =
                        new Paragraph(
                            new Run(
                                new Text($"Data: {DateTime.Now.ToString()}")));
                    parent.InsertBeforeSelf(paragraph);
                    parent.Remove();

                    var sumDoZaplaty = list.Sum(x => x.SumaZaPrzedmiot);
                    bmName = "DoZaplaty";
                    bookmark = res.Single();
                    parent = bookmark.Parent;
                    paragraph =
                        new Paragraph(
                            new Run(
                                new Text($"Do Zapłaty: {sumDoZaplaty.ToString()} zł")));
                    parent.InsertBeforeSelf(paragraph);
                    parent.Remove();

                    var sumKaucja = list.Sum(x => x.Kaucja);
                    bmName = "Kaucja";
                    bookmark = res.Single();
                    parent = bookmark.Parent;
                    paragraph =
                        new Paragraph(
                            new Run(
                                new Text($"Kaucja: {sumKaucja.ToString()} zł")));
                    parent.InsertBeforeSelf(paragraph);
                    parent.Remove();
                }
                document.Close();                
            }
            Process.Start(destinaton);
        }

    }
}
