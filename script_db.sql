USE [EmpresaFicticia]
GO
/****** Object:  Table [dbo].[CadFuncionarios]    Script Date: 15/01/2021 00:18:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CadFuncionarios](
	[Nome] [varchar](50) NOT NULL,
	[Telefone] [varchar](50) NOT NULL,
	[Celular] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RG] [varchar](50) NOT NULL,
	[CPF] [varchar](50) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Logadouro] [varchar](50) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[CEP] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
