#pragma checksum "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Basket\PaymentDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9efab8071dd5e4fd4befbdde13732a921e4ba177"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Basket_PaymentDetails), @"mvc.1.0.view", @"/Views/Basket/PaymentDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9efab8071dd5e4fd4befbdde13732a921e4ba177", @"/Views/Basket/PaymentDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a03eba1a0cf49ee03809835b081d1746d61e78db", @"/Views/_ViewImports.cshtml")]
    public class Views_Basket_PaymentDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaymentVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/paymentDetail.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Basket\PaymentDetails.cshtml"
  
    ViewData["Title"] = "PaymentDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n<h1>Ödeme Yöntemi</h1>\r\n<br />\r\n<br />\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 18 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Basket\PaymentDetails.cshtml"
 using (Html.BeginForm("PaymentDetails", "Basket", FormMethod.Post))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <label>Ödeme Yöntemi: </label> ");
#nullable restore
#line 22 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Basket\PaymentDetails.cshtml"
                                  Write(Html.DropDownListFor(x => x.PaymentType, Html.GetEnumSelectList(typeof(PaymentTypeEnum)), "Seçiniz"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <div class=""row"" id=""CreditCard"" style=""display:none;"">
        <div class=""row"">
            <label>Kart Numarası: </label> <input type=""text"" />
        </div>
        <br />
        <div class=""row"">
            <label>Kart üzerindeki ad: </label> <input type=""text"" />
        </div>
");
            WriteLiteral("    </div>\r\n    <div class=\"row\" id=\"Kiss\" style=\"display:none;\">\r\n        <h3>Give me a kiss :*</h3>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"row\">\r\n        <button type=\"submit\">Ödemeyi Tamamla</button>\r\n    </div>\r\n");
#nullable restore
#line 41 "C:\Users\Samet Şentürk\source\repos\DreamsAndBytes\DreamsAndBytes.UI\Views\Basket\PaymentDetails.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<br />\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9efab8071dd5e4fd4befbdde13732a921e4ba1776248", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaymentVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
