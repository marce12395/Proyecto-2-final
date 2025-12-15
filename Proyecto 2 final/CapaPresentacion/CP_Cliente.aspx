<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CP_Cliente.aspx.cs" Inherits="Proyecto_2_final.CapaPresentacion.CP_Cliente" %>

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
            <h2>Gestión de Clientes</h2>

      
            <label>UsuarioID:</label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>

        
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

         
            <label>Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>

           
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>

           
            <asp:Button ID="btnAgregar" runat="server" CssClass="aspNetButton" Text="Agregar Cliente " OnClick="btnAgregar_Click1"   />
            <asp:Button ID="btnModificar" runat="server" CssClass="aspNetButton" Text="Modificar Cliente por UsuarioID" OnClick="btnModificar_Click1"   />
            <asp:Button ID="btnEliminar" runat="server" CssClass="aspNetButton" Text="Eliminar Cliente por UsuarioID" OnClick="btnEliminar_Click1"  />

           
            <asp:Label ID="lblMensaje" runat="server" CssClass="aspNetLabel" Text=""></asp:Label>
              
   <div class="volver-Principal">
    <asp:HyperLink ID="HyperLinkRegresar" runat="server" NavigateUrl="~/Principal.aspx">
        Regresar a la página principal
    </asp:HyperLink>
</div>

<div>
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="true" CssClass="gridview" Width="701px" />
</div>
            
        

    </form>
</body>
</html>