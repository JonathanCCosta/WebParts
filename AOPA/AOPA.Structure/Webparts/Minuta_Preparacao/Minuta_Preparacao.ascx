<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Minuta_Preparacao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webparts.Minuta_Preparacao.Minuta_Preparacao" %>

<style>
    .gr_space {
        padding:12px;
    }
    #DeltaPlaceHolderMain {
        width:auto!important;
    }
    .nomeSite {
        display: none;
    }
    .bts {
        margin:20px;
        text-align:right;
    }
</style>

<div>
    <div style="font-size:18px; margin-bottom:25px; font-weight:bold; font-family:Verdana!important; color:#262626;">FASE DE PREPARAÇÃO DA MINUTA</div>
    <div>
        <asp:GridView ID="grdPreparacao" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" OnRowDataBound="grdPreparacao_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Nível" DataField="Nivel" HeaderStyle-Width="50" >
                    <HeaderStyle Width="50px"></HeaderStyle>
                <ItemStyle CssClass="gr_space" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Título" DataField="Title" HeaderStyle-Width="200" >
<HeaderStyle Width="200px"></HeaderStyle>
                <ItemStyle CssClass="gr_space" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Conteúdo" DataField="Conteudo" HeaderStyle-Width="250" HtmlEncode="False" >
<HeaderStyle Width="350px"></HeaderStyle>
                <ItemStyle CssClass="gr_space" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Comentário DA" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtComentario" name="S1" runat="server" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtComentarioDA" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("ComentarioDA") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Justificativa DA" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtJustificativa" runat="server" name="S1" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtJustificativaDA" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("JustificativaDA") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comentário DE" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtComentario" name="S1" runat="server" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtComentarioDE" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("ComentarioDE") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Justificativa DE" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtJustificativa" runat="server" name="S1" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtJustificativaDE" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("JustificativaDE") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comentário DF" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtComentario" name="S1" runat="server" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtComentarioDF" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("ComentarioDF") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Justificativa DF" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtJustificativa" runat="server" name="S1" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtJustificativaDF" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("JustificativaDF") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comentário DN" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtComentario" name="S1" runat="server" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtComentarioDN" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("ComentarioDN") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Justificativa DN" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtJustificativa" runat="server" name="S1" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtJustificativaDN" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("JustificativaDN") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comentário DO" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtComentario" name="S1" runat="server" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtComentarioDO" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("ComentarioDO") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Justificativa DO" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtJustificativa" runat="server" name="S1" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ClientIDMode="Static" ID="txtJustificativaDO" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("JustificativaDO") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comentário DP" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtComentario" name="S1" runat="server" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtComentarioDP" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("ComentarioDP") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Justificativa DP" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <%--<textarea id="txtJustificativa" runat="server" name="S1" style="height: 120px; width: 300px"></textarea>--%>
                        <asp:TextBox ID="txtJustificativaDP" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("JustificativaDP") %>'></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#666" HorizontalAlign="Center" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" CssClass="gr_space" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" CssClass="gr_space" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div> 

    <div runat="server" visible="false" id="LabelPrazo" style="font-size:14px; margin-bottom:25px; font-family:Verdana!important; color:RED;">
        PRAZO PARA ANÁLISE DA MINUTA JÁ SE ENCERROU! DÚVIDAS ENTRAR EM CONTATO PELO EMAIL: AOPA@FURNAS.COM.BR
    </div>

    <div class="bts" runat="server" id="bts">
        <asp:Button ID="btn_salva" runat="server" Text="Salvar" OnClick="btn_salva_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="cancelar" runat="server" Text="Voltar" OnClientClick="javascript:window.history.back(1); return false;" />        
    </div>
</div>