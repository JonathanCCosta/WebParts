<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Minuta_AnaliseConsolidacao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webparts.Minuta_AnaliseConsolidacao.Minuta_AnaliseConsolidacao" %>


<style>
    .gr_space {
        padding:12px;
    }
    #DeltaPlaceHolderMain {
        width:2050px!important;
    }
    .nomeSite {
        display: none;
    }
    .bts {
        margin:20px;
        /*width:1000px;*/
        text-align:right;
    }
    .tbInside {
        border-width: 0;
        border-collapse: collapse;
    }
    .trInide {
        border-bottom: 1px solid #777;
    }
    .tdInside {
        border-left: 1px solid #777;
    }
</style>

<script type="text/javascript">
    function OpenDialog(url, title) {
        var options = {
            url: url,
            title: title,
            dialogReturnValueCallback: Function.createDelegate(null, CloseDialogCallback)
        };
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    function CloseDialogCallback(dialogResult, returnValue) {
        //SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.RefreshPage', SP.UI.DialogResult.OK);
        location.reload();
    }
    </script>

<div>
    <div style="font-size:18px; margin-bottom:25px; font-weight:bold; font-family:Verdana!important; color:#262626;">FASE DE ANÁLISE/CONSOLIDAÇÃO DA MINUTA</div>

    <div>
        <asp:GridView ID="grdAnaliseConsolidacao" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdAnaliseConsolidacao_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />

                <asp:BoundField HeaderText="Nível" DataField="Nivel" HeaderStyle-Width="50">
                    <HeaderStyle Width="50px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Título" DataField="Title" HeaderStyle-Width="200">
                    <HeaderStyle Width="200px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Conteúdo" DataField="Conteudo" HeaderStyle-Width="200" HtmlEncode="False">
                    <HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="<span style='padding-left:50px;width:230px;float: left;'>Comentários</span><span style='float: left;width:210px;'>Justificativas</span><span style='float: left;width:140px;'>Status</span><span  style='float: left;width:320px;'>Análise</span>" HeaderStyle-Width="950">
                    <ItemTemplate>
                        <table border="0" class="tbInside" cellpadding="5px">
                            <%--<tr class="trInide" id="firstTB" runat="server">
                                <td></td>
                                <td class="tdInside">Comentários</td>
                                <td class="tdInside">Justificativas</td>
                            </tr>--%>
                            <tr class="trInide" id="trDA" runat="server">
                                <td style="width:50px">DA</td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="txtComentarioDA" ClientIDMode="Static" runat="server" Text='<%#Bind("ComentarioDA") %>'></asp:Label></td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="JustificativaDA" ClientIDMode="Static" runat="server" Text='<%#Bind("JustificativaDA") %>'></asp:Label></td>
                                <td style="width:130px" class="tdInside"><asp:DropDownList ID="dprStatusDA" ClientIDMode="Static" runat="server" Width="120px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Não Incorporado" Value="Não Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Parcialmente Incorporado" Value="Parcialmente Incorporado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:350px" class="tdInside"><asp:TextBox ID="txtAnaliseDA" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="25" Text='<%#Bind("AvaliacaoDA") %>'></asp:TextBox></td>
                            </tr>
                            <tr class="trInide" id="trDE" runat="server">
                                <td style="width:50px">DE</td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="txtComentarioDE" ClientIDMode="Static" runat="server" Text='<%#Bind("ComentarioDE") %>'></asp:Label></td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="JustificativaDE" ClientIDMode="Static" runat="server" Text='<%#Bind("JustificativaDE") %>'></asp:Label></td>
                                <td style="width:130px" class="tdInside"><asp:DropDownList ID="dprStatusDE" ClientIDMode="Static" runat="server" Width="120px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Não Incorporado" Value="Não Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Parcialmente Incorporado" Value="Parcialmente Incorporado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:350px" class="tdInside"><asp:TextBox ID="txtAnaliseDE" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="25" Text='<%#Bind("AvaliacaoDE") %>'></asp:TextBox></td>
                            </tr>
                            <tr class="trInide" id="trDF" runat="server">
                                <td style="width:50px">DF</td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="txtComentarioDF" ClientIDMode="Static" runat="server" Text='<%#Bind("ComentarioDF") %>'></asp:Label></td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="JustificativaDF" ClientIDMode="Static" runat="server" Text='<%#Bind("JustificativaDF") %>'></asp:Label></td>
                                <td style="width:130px" class="tdInside"><asp:DropDownList ID="dprStatusDF" ClientIDMode="Static" runat="server" Width="120px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Não Incorporado" Value="Não Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Parcialmente Incorporado" Value="Parcialmente Incorporado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:350px" class="tdInside"><asp:TextBox ID="txtAnaliseDF" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="25" Text='<%#Bind("AvaliacaoDF") %>'></asp:TextBox></td>
                            </tr>
                            <tr class="trInide" id="trDN" runat="server">
                                <td style="width:50px">DN</td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="txtComentarioDN" ClientIDMode="Static" runat="server" Text='<%#Bind("ComentarioDN") %>'></asp:Label></td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="JustificativaDN" ClientIDMode="Static" runat="server" Text='<%#Bind("JustificativaDN") %>'></asp:Label></td>
                                <td style="width:130px" class="tdInside"><asp:DropDownList ID="dprStatusDN" ClientIDMode="Static" runat="server" Width="120px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Não Incorporado" Value="Não Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Parcialmente Incorporado" Value="Parcialmente Incorporado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:350px" class="tdInside"><asp:TextBox ID="txtAnaliseDN" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="25" Text='<%#Bind("AvaliacaoDN") %>'></asp:TextBox></td>
                            </tr>
                            <tr class="trInide" id="trDP" runat="server">
                                <td style="width:50px">DP</td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="txtComentarioDP" ClientIDMode="Static" runat="server" Text='<%#Bind("ComentarioDP") %>'></asp:Label></td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="JustificativaDP" ClientIDMode="Static" runat="server" Text='<%#Bind("JustificativaDP") %>'></asp:Label></td>
                                <td style="width:130px" class="tdInside"><asp:DropDownList ID="dprStatusDP" ClientIDMode="Static" runat="server" Width="120px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Não Incorporado" Value="Não Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Parcialmente Incorporado" Value="Parcialmente Incorporado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:350px" class="tdInside"><asp:TextBox ID="txtAnaliseDP" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="25" Text='<%#Bind("AvaliacaoDP") %>'></asp:TextBox></td>
                            </tr>
                            <tr id="trDO" runat="server">
                                <td style="width:50px">DO</td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="txtComentarioDO" ClientIDMode="Static" runat="server" Text='<%#Bind("ComentarioDO") %>'></asp:Label></td>
                                <td style="width:230px" class="tdInside"><asp:Label ID="JustificativaDO" ClientIDMode="Static" runat="server" Text='<%#Bind("JustificativaDO") %>'></asp:Label></td>
                                <td style="width:130px" class="tdInside"><asp:DropDownList ID="dprStatusDO" ClientIDMode="Static" runat="server" Width="120px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Não Incorporado" Value="Não Incorporado"></asp:ListItem>
                                        <asp:ListItem Text="Parcialmente Incorporado" Value="Parcialmente Incorporado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:350px" class="tdInside"><asp:TextBox ID="txtAnaliseDO" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="25" Text='<%#Bind("AvaliacaoDO") %>'></asp:TextBox></td>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle Width="950px"></HeaderStyle>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Status" HeaderStyle-Width="170">
                    <ItemTemplate>
                        <asp:DropDownList ID="dprStatus" ClientIDMode="Static" runat="server">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Incorporado" Value="Incorporado"></asp:ListItem>
                            <asp:ListItem Text="Não Incorporado" Value="Incorporado"></asp:ListItem>
                            <asp:ListItem Text="Parcialmente Incorporado" Value="Incorporado"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <HeaderStyle Width="170px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>--%>

                <%--<asp:TemplateField HeaderText="Análise" HeaderStyle-Width="350">
                    <ItemTemplate>
                        <asp:TextBox ID="txtAnalise" ClientIDMode="Static" runat="server" Rows="10" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("Avaliacao") %>'></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle Width="350px"></HeaderStyle>
                    <ItemStyle CssClass="gr_space" />
                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="Texto Final" HeaderStyle-Width="450">
                    <ItemTemplate>
                        <asp:TextBox ID="txtTextoFinal" ClientIDMode="Static" runat="server" Rows="20" TextMode="MultiLine" Width="95%" Columns="40" Text='<%#Bind("TextoFinal") %>'></asp:TextBox>
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
    <div class="bts">
        <asp:Button ID="btn_salva" runat="server" Text="Salvar" OnClick="btn_salva_Click" />
        <%--<asp:Button ID="btn_salva2" runat="server" Text="Salvar Consolidação" />--%>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Aprovacao" runat="server" Visible="false" Text="Publicar Ato Normativo" OnClick="btn_Aprovacao_Click" />
        <%--<asp:Button ID="cancelar" runat="server" Text="Voltar" OnClientClick="javascript:window.history.back(1); return false;" />--%>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_addNovoItem" runat="server" Visible="false" Text="Adicionar Novo Item" />
    </div>
</div>
