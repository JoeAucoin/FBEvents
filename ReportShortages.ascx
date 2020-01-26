<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportShortages.ascx.cs" Inherits="GIBS.Modules.FBEvents.ReportShortages" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBEvents/Css/Style.css" />

<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />
<script type="text/javascript">

    $(function () {
        $("#txtStartDate").datepicker({
            numberOfMonths: 2,
            showButtonPanel: false,
            showCurrentAtPos: 0});
        $("#txtEndDate").datepicker({
            numberOfMonths: 2,
            showButtonPanel: false,
            showCurrentAtPos: 0
        });
    });

 </script>
<div style=" float:right">
<asp:Button ID="btnGetSchedule" runat="server" Text="Button" ResourceKey="btnGetSchedule" onclick="btnGetSchedule_Click" CssClass="dnnPrimaryAction" /></div>
<div class="dnnForm" id="form-demo">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblStartDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtStartDate" Text="Start Date" />
            <asp:TextBox ID="txtStartDate" runat="server" ClientIDMode="Static" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblEndDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtEndDate" Text="Start Date" />
            <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static" />
        </div>		
    </fieldset>
</div>	





<asp:GridView ID="gv_Report" runat="server"          
    AutoGenerateColumns="False" CssClass="dnnGrid" OnSorting="gv_Report_Sorting"  
    resourcekey="gv_ReportDetails" EnableViewState="False" DataKeyNames="EventID" Width="100%">
    <HeaderStyle CssClass="dnnGridHeader" />
    <RowStyle CssClass="dnnGridItem" />
<AlternatingRowStyle CssClass="dnnGridAltItem" />    

<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>
    
        <asp:BoundField HeaderText="Day" DataField="ShiftDayOfWeek" SortExpression="Day" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="Shift Date" DataField="ShiftDate" SortExpression="ShiftDate" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
        <asp:BoundField HeaderText="Start Time" DataField="ShiftStartTime" SortExpression="StartTime" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Shift Name" DataField="ShiftName" SortExpression="ShiftName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="Hours" DataField="Duration" SortExpression="Duration" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
        <asp:BoundField HeaderText="# Needed" DataField="MaxEnrollment" SortExpression="MaxEnrollment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Enrolled" DataField="Enrolled" SortExpression="Enrolled" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

        <asp:TemplateField HeaderText="Full Enrollment" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
            <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# (Eval("FullEnrollment").Equals(true) ? "~/DesktopModules/GIBS/FBEvents/Images/yes.png" : "~/DesktopModules/GIBS/FBEvents/Images/not_equal.png")%>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>	