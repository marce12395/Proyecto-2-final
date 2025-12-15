<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CP_Detalles.aspx.cs" Inherits="Proyecto_2_final.CapaPresentacion.CP_Detalles" %>

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
            <h2>Detalles de la reparacion</h2>

      
            <label>DetalleID:</label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>

        
            <label>ReparacionID:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

         
            <label>Descripcion:</label>
            <asp:TextBox ID="txtdescripcion" runat="server"></asp:TextBox>

             <label>Fecha de Inicio :</label>
         <asp:TextBox ID="fechaI" TextMode="Date" runat="server" Height="31px" Width="691px"></asp:TextBox>

             <label>Fecha de entrega:</label>
         <asp:TextBox ID="fechaE" TextMode="Date" runat="server" Height="31px" Width="691px"></asp:TextBox>



           
            &nbsp;<asp:Button ID="btnAgregar" runat="server" CssClass="aspNetButton" Text="Agregar Cliente" OnClick="btnAgregar_Click"    />
            <asp:Button ID="btnModificar" runat="server" CssClass="aspNetButton" Text="Modificar Cliente con  DetalleID" OnClick="btnModificar_Click"   />
            <asp:Button ID="btnEliminar" runat="server" CssClass="aspNetButton" Text="Eliminar Cliente con  DetalleID" OnClick="btnEliminar_Click"   />

           
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
