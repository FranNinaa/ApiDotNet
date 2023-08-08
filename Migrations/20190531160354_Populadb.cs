using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas','')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Lanches','')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Sobremesas','')");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                                "Values('Coca-Cola Diet','Refrigerante de Cola 350 ml',5.45,'',50,now(),(Select CategoriaId from Categorias where Nome='Bebidas'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                                "Values('Lanche de Atum','Lanche de Atum com maionese',8.50,'',10,now(),(Select CategoriaId from Categorias where Nome='Lanches'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                                "Values('Pudim 100 g','Pudim de leite condensado 100g',6.75,'',20,now(),(Select CategoriaId from Categorias where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
