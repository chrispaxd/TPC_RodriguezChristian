﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SegundaPantalla.aspx.cs" Inherits="TPC_RodriguezChristian.SegundaPantalla" %>


<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnCargarPublicacion" runat="server" Text="Cargar nueva publicacion" OnClick="btnCargar_Click" class="btn btn-primary btn-sm"  />
    <asp:Button ID="btnListar" runat="server" Text="Listar productos" OnClick="btnListar_Click" class="btn btn-primary btn-sm" />
    <asp:Button ID="btnPerfil" runat="server" Text="Mi perfil" OnClick="btnPerfil_Click" class="btn btn-primary btn-sm" />
    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click"  class="btn btn-primary btn-sm"/>
    </asp:Content>

