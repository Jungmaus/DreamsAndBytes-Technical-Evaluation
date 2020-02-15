#pragma checksum "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c11956b817de352cb109317c23fd443a63988997"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Add), @"mvc.1.0.view", @"/Views/Product/Add.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\_ViewImports.cshtml"
using DreamsAndBytes.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\_ViewImports.cshtml"
using DreamsAndBytes.UI.Models.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\_ViewImports.cshtml"
using DreamsAndBytes.UI.Models.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\_ViewImports.cshtml"
using DreamsAndBytes.UI.Models.Payment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\_ViewImports.cshtml"
using DreamsAndBytes.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c11956b817de352cb109317c23fd443a63988997", @"/Views/Product/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a03eba1a0cf49ee03809835b081d1746d61e78db", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddProductVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
  
    ViewData["Title"] = "Ürün Ekle";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<h1>Ürün Ekle</h1>\r\n\r\n<br />\r\n<br />\r\n\r\n");
#nullable restore
#line 16 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
 using (Html.BeginForm("Add", "Product", FormMethod.Post, new { enctype="multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <label>Ürün Resmi: </label> ");
#nullable restore
#line 20 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
                               Write(Html.TextBoxFor(x => x.Image, new { @type = "file" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"validationRow\">\r\n            <label>");
#nullable restore
#line 22 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
              Write(Html.ValidationMessageFor(x => x.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <label>Ürün Adı: </label> ");
#nullable restore
#line 26 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
                             Write(Html.TextBoxFor(x => x.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"validationRow\">\r\n            <label>");
#nullable restore
#line 28 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
              Write(Html.ValidationMessageFor(x => x.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <label>Ürün Türü: </label> ");
#nullable restore
#line 32 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
                              Write(Html.DropDownListFor(x => x.ProductTypeId, Model.ProductTypeSelectList, "Seçiniz"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"validationRow\">\r\n            <label>");
#nullable restore
#line 34 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
              Write(Html.ValidationMessageFor(x => x.ProductTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <label>Stok Adedi: </label> ");
#nullable restore
#line 38 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
                               Write(Html.TextBoxFor(x => x.StockCount, new { @type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"validationRow\">\r\n            <label>");
#nullable restore
#line 40 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
              Write(Html.ValidationMessageFor(x => x.StockCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <label>Fiyat: </label> ");
#nullable restore
#line 44 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
                          Write(Html.TextBoxFor(x => x.Price, new { @type = "number",@step=".01" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"validationRow\">\r\n            <label>");
#nullable restore
#line 46 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
              Write(Html.ValidationMessageFor(x => x.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <button type=\"submit\">Kaydet</button>\r\n    </div>\r\n");
#nullable restore
#line 52 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"

    if (ViewBag.OperationResult != null && ViewBag.OperationResult == OperationResultEnum.Success)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label style=\"color:green;\"><br /><b>Ürün başarıyla eklendi !</b></label>\r\n");
#nullable restore
#line 56 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
    }
    else if (ViewBag.OperationResult != null && ViewBag.OperationResult == OperationResultEnum.Failure)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label style=\"color:red;\"><br /><b>Ürün eklenirken bir sorun oluştu !</b></label>\r\n");
#nullable restore
#line 60 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Product\Add.cshtml"
    }


}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<br />\r\n<br />\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddProductVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
