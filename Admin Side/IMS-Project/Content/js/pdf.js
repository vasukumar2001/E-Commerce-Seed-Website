function generatePDF() {
    const element = document.getElementById("invoice");
    var opt = {

        filename: 'invoice.pdf',
    };
    html2pdf().from(invoice).set(opt).save();
    /*  html2pdf()
           .from(element)
          .save();*/
}
