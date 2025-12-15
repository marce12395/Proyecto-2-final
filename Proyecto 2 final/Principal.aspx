<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Proyecto_2_final.Principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Página Principal</title>
   <link href="css/principal.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
            <h2>Bienvenido/a a la página principal</h2>
            <asp:Label ID="lblMensaje" runat="server" Text="Seleccione una opción para continuar."></asp:Label>
            <asp:Label ID="Lbnombre" runat="server" CssClass="nombre-label"></asp:Label>

        
            <div class="menu-grid">

              
                <asp:HyperLink ID="linkUsuarios" runat="server" NavigateUrl="CapaPresentacion/CP_Cliente.aspx" CssClass="menu-box">
                    <div class="menu-title">Usuarios</div>
                    <div class="menu-desc">Ingresar los datos del cliente.</div>
                </asp:HyperLink>

            
                <asp:HyperLink ID="linkEquipos" runat="server" NavigateUrl="CapaPresentacion/CP_Equipos.aspx" CssClass="menu-box">
                    <div class="menu-title">Equipos</div>
                    <div class="menu-desc">Registrar y consultar datos de los equipos.</div>
                </asp:HyperLink>

          
                <asp:HyperLink ID="linkReparaciones" runat="server" NavigateUrl="CapaPresentacion/CP_Reparaciones.aspx" CssClass="menu-box">
                    <div class="menu-title">Reparaciones</div>
                    <div class="menu-desc">Crear y gestionar solicitudes de reparación.</div>
                </asp:HyperLink>

             
                <asp:HyperLink ID="linkDetalles" runat="server" NavigateUrl="CapaPresentacion/CP_Detalles.aspx" CssClass="menu-box">
                    <div class="menu-title">Detalles</div>
                    <div class="menu-desc">Registrar avances y fechas de cada reparación.</div>
                </asp:HyperLink>
           
                <asp:HyperLink ID="linkAsignaciones" runat="server" NavigateUrl="CapaPresentacion/CP_Asignaciones.aspx" CssClass="menu-box">
                    <div class="menu-title">Asignaciones</div>
                    <div class="menu-desc">Asignar técnicos a reparaciones específicas.</div>
                </asp:HyperLink>
               
 <asp:HyperLink ID="linkTecnicos" runat="server" NavigateUrl="CapaPresentacion/CP_Tecnicos.aspx" CssClass="menu-box">
     <div class="menu-title">Técnicos</div>
     <div class="menu-desc">Ingresar y consultar datos de los técnicos.</div>
 </asp:HyperLink>
            </div>

           
            <div class="volver-inicio">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="inicio.aspx">Cerrar sesión</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
