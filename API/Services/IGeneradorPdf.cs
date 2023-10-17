
public interface IGeneradorPdf{
    MemoryStream Generador<T>(List<T> lstProductDto);
    void Body<T>(List<T> lstProductDto, MemoryStream ms);
    void Header(Document doc, PdfDocument pdfDocument);
}