#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\DoiMatKhau.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a159ab80f241321a577f8e65d476351a7ce80d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nhanvien_DoiMatKhau), @"mvc.1.0.view", @"/Views/Nhanvien/DoiMatKhau.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Nhanvien/DoiMatKhau.cshtml", typeof(AspNetCore.Views_Nhanvien_DoiMatKhau))]
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
#line 1 "E:\Repos\Assignment01\Assignment01\Views\_ViewImports.cshtml"
using Assignment01;

#line default
#line hidden
#line 2 "E:\Repos\Assignment01\Assignment01\Views\_ViewImports.cshtml"
using Assignment01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a159ab80f241321a577f8e65d476351a7ce80d6", @"/Views/Nhanvien/DoiMatKhau.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_Nhanvien_DoiMatKhau : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\DoiMatKhau.cshtml"
  
    ViewData["Title"] = "Đổi mật khẩu";
    var thongTinNhanVien = ViewData["thongTinNhanVien"] as NhanVien;

#line default
#line hidden
            BeginContext(120, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 8 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\DoiMatKhau.cshtml"
   
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(164, 170, true);
            WriteLiteral("\r\n<div id=\"page-wrapper\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <h1 class=\"page-header\">Đổi mật khẩu</h1>\r\n        </div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(334, 2140, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fb618bd8e394648a761cb269d5113a6", async() => {
                BeginContext(405, 2062, true);
                WriteLiteral(@"
        <div class=""row"" style=""margin-top: 30px;"">
            <div class=""col-lg-12"">
                <div class=""row"" style=""padding: 10px;"">
                    <div class=""col-md-2""><label for=""oldPasswordInput"" class="""">Mật khẩu cũ:</label></div>
                    <div class=""col-md-4""><input id=""oldPasswordInput"" name=""oldPassword"" class=""form-control"" type=""password"" placeholder=""Nhập mật khẩu cũ"" /></div>
                    <div class=""col-md-2""></div>
                </div>

                <div class=""row"" style=""padding: 10px;"">
                    <div class=""col-md-2""><label for=""newPasswordInput"" class="""">Mật khẩu mới:</label></div>
                    <div class=""col-md-4""><input id=""newPasswordInput"" onkeyup=""checkRepeatPassword();"" name=""newPassword"" class=""form-control"" type=""password"" placeholder=""Nhập mật khẩu mới"" /></div>
                    <div class=""col-md-2"">
                        <input type=""checkbox"" onclick=""revealPassword();"" class="""" id=""showPassword"" />
 ");
                WriteLiteral(@"                       <label for=""showPassword"" onclick=""revealPassword();"">Hiển thị mật khẩu</label>
                    </div>
                </div>

                <div class=""row"" style=""padding: 10px;"">
                    <div class=""col-md-2""><label for=""repeatPasswordInput"" class="""">Mật lại khẩu mới:</label></div>
                    <div class=""col-md-4""><input id=""repeatPasswordInput"" onkeyup=""checkRepeatPassword();"" class=""form-control"" type=""password"" placeholder=""Nhập lại mật khẩu mới"" /></div>
                    <div class=""col-md-2"">
                        <span id=""helpBlock"" class=""help-block"" style=""color: red""></span>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"" style=""padding: 10px;"">
            <div class=""col-md-4""></div>
            <div class=""col-md-4""><button type=""submit"" class=""btn btn-default"">Đổi mật khẩu</button></div>
            <div class=""col-md-4""></div>
        </div>
        <p ></p>
");
                WriteLiteral("        \r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 362, "/Nhanvien/", 362, 10, true);
#line 18 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\DoiMatKhau.cshtml"
AddHtmlAttributeValue("", 372, thongTinNhanVien.Id, 372, 20, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 392, "/Doimatkhau", 392, 11, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2474, 1091, true);
            WriteLiteral(@"
    
</div>

<script>
    function revealPassword() {
        var checkBox = document.getElementById(""showPassword"");
        var passwordField = document.getElementById(""newPasswordInput"");
 
        if (checkBox.checked) {
            passwordField.type = ""text"";
        } else {
            passwordField.type = ""password"";
        }
    }

    function checkRepeatPassword() {
        var newPasswordInput = document.getElementById(""newPasswordInput"");
        var newPasswordRepeat = document.getElementById(""repeatPasswordInput"");
        var help = document.getElementById(""helpBlock"");
        if (newPasswordInput.value != newPasswordRepeat.value) {
            help.innerText = ""Mật khẩu nhập lại không trùng khớp."";
            newPasswordInput.style = ""border: 1px solid red"";
            newPasswordRepeat.style = ""border: 1px solid red"";
        } else {
            newPasswordInput.style = ""border: 1px solid green"";
            newPasswordRepeat.style = ""border: 1px solid green""");
            WriteLiteral(";\r\n            help.innerText = \"\"\r\n        }\r\n    }\r\n\r\n</script>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
