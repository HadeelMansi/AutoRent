#pragma checksum "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6859ea196f40f4da318ddec9c022b1188325dc0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Company_Views_Cars_Index), @"mvc.1.0.view", @"/Areas/Company/Views/Cars/Index.cshtml")]
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
#line 1 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\_ViewImports.cshtml"
using AutoRent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\_ViewImports.cshtml"
using AutoRent.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6859ea196f40f4da318ddec9c022b1188325dc0f", @"/Areas/Company/Views/Cars/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3eead999616107fd0241bda3a42f50bf3b96a2f6", @"/Areas/Company/Views/_ViewImports.cshtml")]
    public class Areas_Company_Views_Cars_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AutoRent.Models.Car>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary px-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Company/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6859ea196f40f4da318ddec9c022b1188325dc0f4921", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<span class=\"text-danger\">");
#nullable restore
#line 12 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                     Write(ViewBag.CarAddMsg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6859ea196f40f4da318ddec9c022b1188325dc0f6380", async() => {
                WriteLiteral("\r\n    <div></div>\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 16 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"col-lg-4 col-md-6 mb-2\">\r\n                <div class=\"rent-item  mb-4\">\r\n                    <img class=\"img-fluid mb-4\"");
                BeginWriteAttribute("src", " src=\"", 1065, "\"", 1097, 1);
#nullable restore
#line 33 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
WriteAttributeValue("", 1071, Url.Content(item.CarLogo), 1071, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"150px\" height=\"150px\"");
                BeginWriteAttribute("alt", " alt=\"", 1127, "\"", 1133, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <h4 class=\"text-uppercase mb-4\">");
#nullable restore
#line 34 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                                               Write(item.CarDesc);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                    <div class=\"d-flex justify-content-center mb-4\">\r\n                        <div class=\"px-2\">\r\n                            <i class=\"fa fa-car text-primary mr-1\"></i>\r\n                            <span>");
#nullable restore
#line 38 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                             Write(item.ProdYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"px-2 border-left border-right\">\r\n                            <i class=\"fa fa-cogs text-primary mr-1\"></i>\r\n                            <span>");
#nullable restore
#line 42 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                             Write(item.GearType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"px-2\">\r\n                                <i class=\"fa fa-road text-primary mr-1\"></i>\r\n                                <span>");
#nullable restore
#line 46 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                                 Write(item.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" $/Day</span>\r\n                         </div>\r\n                    </div>\r\n\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6859ea196f40f4da318ddec9c022b1188325dc0f9605", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                                                                        WriteLiteral(item.CarId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6859ea196f40f4da318ddec9c022b1188325dc0f12004", async() => {
                    WriteLiteral("View");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
                                                                           WriteLiteral(item.CarId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 55 "C:\Users\hadeel.almansi\source\repos\AutoRent\AutoRent\Areas\Company\Views\Cars\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AutoRent.Models.Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591