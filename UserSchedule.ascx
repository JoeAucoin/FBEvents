<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserSchedule.ascx.cs" Inherits="GIBS.Modules.FBEvents.UserSchedule" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBEvents/Css/Style.css" />
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />

<script type="text/javascript">

    $(function () {
        $("#txtStartDate").datepicker({
            numberOfMonths: 1,
            showButtonPanel: false,
            showCurrentAtPos: 0});
        $("#txtEndDate").datepicker({
            showButtonPanel: false
        });
    });

 </script>

<div class="dnnForm" id="form-settings">

    <fieldset>

       
        <div class="dnnFormItem">
            <dnn:label id="lblRolesDropdown" runat="server" suffix=":" controlname="ddlRolesDropdown" ResourceKey="lblRolesDropdown" />
           <asp:dropdownlist id="ddlRolesDropdown" Runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlRolesDropdown_SelectedIndexChanged"></asp:dropdownlist>
            
        </div>
       
       <div class="dnnFormItem">
            <dnn:label id="lblUserDropdown" runat="server" suffix=":" controlname="ddlUserDropdown" ResourceKey="lblUserDropdown" />
           <asp:dropdownlist id="ddlUserDropdown" Runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlUserDropdown_SelectedIndexChanged"></asp:dropdownlist>
            
        </div>

		<div>

<asp:GridView ID="gv_Report" runat="server" HorizontalAlign="Center"  
    AutoGenerateColumns="False" CssClass="dnnGrid" OnSorting="gv_Report_Sorting"  
    resourcekey="gv_ReportDetails" EnableViewState="False" DataKeyNames="UserID" EmptyDataText="No Enrollments Found For This Volunteer">
    <HeaderStyle CssClass="dnnGridHeader" />
    <RowStyle CssClass="dnnGridItem" />
<AlternatingRowStyle CssClass="dnnGridAltItem" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>
        <asp:BoundField HeaderText="Shift Date" DataField="ShiftDate" SortExpression="ShiftDate" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
        <asp:BoundField HeaderText="Day" DataField="ShiftDayOfWeek" SortExpression="Day" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Start Time" DataField="ShiftStartTime" SortExpression="StartTime" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="Shift Name" DataField="ShiftName" SortExpression="ShiftName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
		<asp:BoundField HeaderText="Hours" DataField="Duration" SortExpression="Duration" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="Volunteer Name" DataField="VolunteerName" SortExpression="VolunteerName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Primary Job" DataField="PrimaryJob" SortExpression="PrimaryJob" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
		<asp:BoundField HeaderText="Email" DataField="VolunteerEmail" SortExpression="Email" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Primary Telephone" DataField="PrimaryTelephone" SortExpression="Telephone" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="# Needed" DataField="MaxEnrollment" SortExpression="MaxEnrollment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Enrolled" DataField="Enrolled" SortExpression="Enrolled" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>

    </Columns>
</asp:GridView>	        
        
        </div>



        <div class="dnnFormItem">
            <dnn:Label ID="lblStartDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtStartDate"  />
            <asp:TextBox ID="txtStartDate" runat="server" ClientIDMode="Static" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblEndDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtEndDate" />
            <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static" />
        </div>	


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblEventDropdown" ControlName="ddlEventDropdown" ResourceKey="lblEventDropdown" Suffix=":" />
            <asp:dropdownlist id="ddlEventDropdown" Runat="server"></asp:dropdownlist><asp:Button ID="btnAddShift" runat="server" Text="Add Shift" 
                onclick="btnAddShift_Click" />
        </div>	



    </fieldset>

 </div>