<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CP_Reparaciones.aspx.cs" Inherits="Proyecto_2_final.CapaPresentacion.CP_Reparaciones" %>

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
            <h2>Reparaciones</h2>

      
            <label>ReparacionesID:</label>
            <asp:TextBox ID="txtreparacionID" runat="server"></asp:TextBox>

        
            <label>EquipoID:</label>
            <asp:TextBox ID="txtequipo" runat="server"></asp:TextBox>

         
            <br />
            <label>Fecla de Solicitud:</label>
            <asp:TextBox ID="fechaS" TextMode="Date" runat="server" Height="31px" Width="691px"></asp:TextBox>

           
            <label>Estado del dispositivo:</label>
            <asp:TextBox ID="txtestado" runat="server"></asp:TextBox>

           
            <asp:Button ID="btnAgregar" runat="server" CssClass="aspNetButton" Text="Agregar Cliente" OnClick="btnAgregar_Click1"   />
            <asp:Button ID="btnModificar" runat="server" CssClass="aspNetButton" Text="Modificar Cliente por ReparacionesID" OnClick="btnModificar_Click1"   />
            <asp:Button ID="btnEliminar" runat="server" CssClass="aspNetButton" Text="Eliminar Cliente por ReparacionesID" OnClick="btnEliminar_Click1"  />

           
            <asp:Label ID="lblMensaje" runat="server" CssClass="aspNetLabel" Text=""></asp:Label>
              
   <div class="volver-Principal">
    <asp:HyperLink ID="HyperLinkRegresar" runat="server" NavigateUrl="~/Principal.aspx">
        Regresar a la página principal
    </asp:HyperLink>
</div>

<div>
    <asp:GridView ID="gvreparaciones" runat="server" AutoGenerateColumns="true" CssClass="gridview" Width="701px" />
</div>
            
        

    </form>
</body>
</html>