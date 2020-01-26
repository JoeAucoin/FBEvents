<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewFBEvents.ascx.cs" Inherits="GIBS.Modules.FBEvents.ViewFBEvents" %>
<%@ Register Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" TagPrefix="dnn" %>

<style type="text/css" media="all">
#navFBEvents
{
    list-style: none;
    margin-bottom: 10px;
    margin-left: -6px;
    padding-bottom:15px;
    z-index: 9;
    height: 26px;
    padding: 4px 10px 4px 10px;
    font-weight: bold;	
}

#navFBEvents li
{
    list-style: none;
     
    margin-right: 10px;
    margin-bottom: 10px;
    width:200px;
    border: 1px solid grey;
    text-align: center;
}

#navFBEvents a
{
    display: block;
    padding: 5px;
    color: #444444;
    background: #ccc;
    text-decoration: none;
    margin:3px;    
}


#navFBEvents a:hover
{
    color: #fff;
    background: #006699;
}

</style>

<ul id="navFBEvents1">
   
    <li><asp:HyperLink ID="HyperLink5" runat="server">UserSchedule</asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink4" runat="server">ContactShift</asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink1" runat="server">WhosScheduledReport</asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink2" runat="server">ShortageReport</asp:HyperLink></li>

</ul>

<p>-----</p>