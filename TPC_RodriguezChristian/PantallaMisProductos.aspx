﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PantallaMisProductos.aspx.cs" Inherits="TPC_RodriguezChristian.PantallaMisProductos" %>

<asp:Content ID="PantallaListarMisProductos" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1 class="text-center">Mis Publicaciones</h1>

           <asp:Label ID="Label1" runat="server" Text="No tienes publicaciones activas" Visible="false"  ></asp:Label>
       
        <div class=" style="border:1px solid #808080 ;box-shadow: 0px 2px 5px #000000;">
      <asp:Repeater runat="server" ID="rptOutter"  >
            <ItemTemplate>
                <div class="card">
                    <img src="<%#Eval("urlImagen") %>" class="card-img-top" alt="..." style="max-height:250px;max-width:250px">
                    <div class="card-body">
                <h5 class="card-title">Titulo: <%#Eval("titulo")%> </h5>
                <p class="card-text">Descripcion: <%#Eval("descripcion")%> </p>
                  <p class="card-text">Stock: <%#Eval("stock")%> </p>
      
                   
             <a class="btn btn-primary" href="PantallaModificarProducto.aspx?id=<%#Eval("Id")%>">Modificar</a>
             <asp:Button ID="btnEliminar" CssClass="btn btn-primary" Text="Eliminar publicacion" Onclick="btnEliminar_Click" CommandArgument='<%#Eval("id")%>' CommandName="idEliminar" runat="server"  />
                    
                    </div>
                
            </ItemTemplate>
        </asp:Repeater>
            
            </div>
           



</asp:Content>