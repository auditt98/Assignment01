#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e8a18f06ca407a21cc74ba08dff026dbd3e593e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DanhMuc_ChucVu_Xoa), @"mvc.1.0.view", @"/Views/DanhMuc/ChucVu/Xoa.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DanhMuc/ChucVu/Xoa.cshtml", typeof(AspNetCore.Views_DanhMuc_ChucVu_Xoa))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e8a18f06ca407a21cc74ba08dff026dbd3e593e", @"/Views/DanhMuc/ChucVu/Xoa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_DanhMuc_ChucVu_Xoa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
  
    var thongTinNhanVien = ViewData["thongTinNhanVien"] as NhanVien;
    var thongTinChucVu = ViewData["thongTinChucVu"] as ChucVu;
    ViewData["Title"] = "Xóa chức vụ";

#line default
#line hidden
            BeginContext(183, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
  
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(224, 182, true);
            WriteLiteral("\r\n<div id=\"page-wrapper\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <h1 class=\"page-header\">Bạn muốn xóa chức vụ này</h1>\r\n        </div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(406, 1210, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0d5f31b593b4d77b03c4ef9797545de", async() => {
                BeginContext(500, 213, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"inputId\" class=\"col-sm-2 control-label\">Mã chức vụ:</label>\r\n            <div class=\"col-sm-6\">\r\n                <input class=\"form-control\" id=\"inputId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 713, "\"", 752, 1);
#line 22 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
WriteAttributeValue("", 721, thongTinChucVu.Idcv.ToString(), 721, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(753, 68, true);
                WriteLiteral(" disabled />\r\n                <input type=\"hidden\" name=\"deleteCvId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 821, "\"", 860, 1);
#line 23 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
WriteAttributeValue("", 829, thongTinChucVu.Idcv.ToString(), 829, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(861, 303, true);
                WriteLiteral(@"/>
            </div>
        </div>
        <div class=""form-group"">
            <label for=""inputName"" class=""col-sm-2 control-label"">Tên chức vụ <span style=""color:red"">(*)</span>:</label>
            <div class=""col-sm-6"">
                <input type=""text"" class=""form-control"" id=""inputName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1164, "\"", 1193, 1);
#line 29 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
WriteAttributeValue("", 1172, thongTinChucVu.Tencv, 1172, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1194, 68, true);
                WriteLiteral(" disabled>\r\n                <input type=\"hidden\" name=\"deleteCvName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1262, "\"", 1291, 1);
#line 30 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
WriteAttributeValue("", 1270, thongTinChucVu.Tencv, 1270, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1292, 317, true);
                WriteLiteral(@">
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-8"" style=""text-align: center;"">
                <button class=""btn btn-danger"" type=""submit"">Xóa</button>
                <a class=""btn btn-info"" href=""/DanhMuc/ChucVu"">Hủy</a>
            </div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 458, "/DanhMuc/ChucVu/", 458, 16, true);
#line 18 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\Xoa.cshtml"
AddHtmlAttributeValue("", 474, thongTinChucVu.Idcv, 474, 20, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 494, "/Xoa", 494, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1616, 10, true);
            WriteLiteral("\r\n\r\n</div>");
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
