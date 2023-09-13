﻿// <auto-generated />
using System;
using CadastroCliente.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroCliente.Infra.Migrations
{
    [DbContext(typeof(CadastroClienteContext))]
    partial class CadastroClienteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("CadastroCliente.Domain.ClienteEnderecoModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClienteId", "EnderecoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("ClientesEnderecos");
                });

            modelBuilder.Entity("CadastroCliente.Domain.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CadastroCliente.Domain.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CadastroCliente.Domain.ClienteEnderecoModel", b =>
                {
                    b.HasOne("CadastroCliente.Domain.ClienteModel", "Cliente")
                        .WithMany("ClientesEnderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroCliente.Domain.EnderecoModel", "Endereco")
                        .WithMany("ClientesEnderecos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("CadastroCliente.Domain.ClienteModel", b =>
                {
                    b.Navigation("ClientesEnderecos");
                });

            modelBuilder.Entity("CadastroCliente.Domain.EnderecoModel", b =>
                {
                    b.Navigation("ClientesEnderecos");
                });
#pragma warning restore 612, 618
        }
    }
}