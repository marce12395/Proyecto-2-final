<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CP_Equipos.aspx.cs" Inherits="Proyecto_2_final.CapaPresentacion.CP_Equipos" %>

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
            <h2>Gestión de Equipos</h2>
                   
      
            <label>EquiposID:</label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>

                                    <label>UsuarioID:</label>
<asp:TextBox ID="txtu" runat="server"></asp:TextBox>

        
            <label>Tipo de equipo:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

         
            <label>Modelo:</label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>

      

           
            &nbsp;<asp:Button ID="btnAgregar" runat="server" CssClass="aspNetButton" Text="Agregar Cliente" OnClick="btnAgregar_Click"    />
            <asp:Button ID="btnModificar" runat="server" CssClass="aspNetButton" Text="Modificar Cliente por EquipoID" OnClick="btnModificar_Click"    />
            <asp:Button ID="btnEliminar" runat="server" CssClass="aspNetButton" Text="Eliminar Cliente por EquipoID" OnClick="btnEliminar_Click"   />

           
            <asp:Label ID="lblMensaje" runat="server" CssClass="aspNetLabel" Text=""></asp:Label>
              
   <div class="volver-Principal">
    <asp:HyperLink ID="HyperLinkRegresar" runat="server" NavigateUrl="~/Principal.aspx">
        Regresar a la página principal
    </asp:HyperLink>
</div>

<div>
    <asp:GridView ID="gvequipo" runat="server" AutoGenerateColumns="true" CssClass="gridview" Width="701px" />
</div>
            
        

    </form>
</body>
</html>