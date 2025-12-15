<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CP_Tecnicos.aspx.cs" Inherits="Proyecto_2_final.CapaPresentacion.CP_Tecnicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Clientes</title>
    <link href="../css/cliente.css" rel="stylesheet" />
    <style type="text/css">
        .gridview {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <h2>Gestión de Técnicos</h2>

      
            <label>TecnicoID:</label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>

        
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

         
            <label>Especialidad:</label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>

           
            &nbsp;<asp:Button ID="btnAgregar" runat="server" CssClass="aspNetButton" Text="Agregar Cliente" OnClick="btnAgregar_Click1"   />
            <asp:Button ID="btnModificar" runat="server" CssClass="aspNetButton" Text="Modificar Cliente por TecnicoID" OnClick="btnModificar_Click1"   />
            <asp:Button ID="btnEliminar" runat="server" CssClass="aspNetButton" Text="Eliminar Cliente por TecnicoID" OnClick="btnEliminar_Click1"  />

           
            <asp:Label ID="lblMensaje" runat="server" CssClass="aspNetLabel" Text=""></asp:Label>
              
   <div class="volver-Principal">
    <asp:HyperLink ID="HyperLinkRegresar" runat="server" NavigateUrl="~/Principal.aspx">
        Regresar a la página principal
    </asp:HyperLink>
</div>

<div>
    <asp:GridView ID="gvTecnicos" runat="server" AutoGenerateColumns="true" CssClass="gridview" Width="701px" />
</div>
            
        

    </form>
</body>
</html>