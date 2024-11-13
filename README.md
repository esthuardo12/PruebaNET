# PruebaNET

## Instalación local

- ### Clonamos el repositorio
`git clone https://github.com/esthuardo12/PruebaNET.git`

- ### Configuración de la base de datos y webAPI
Creamos una base de datos llamada PruebaNET y luego creamos las tablas con su relación:
```bash
USE [PruebaNET]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/11/2024 19:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Stock] [int] NULL,
	[Description] [nvarchar](250) NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 8/11/2024 19:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Status] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Status])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Status]
GO
```

Insertamos los valores de la tabla Status:

```bash
insert into Status (StatusName) values ('Inactive'),('Active');
```
Finalmente en el archivo "PruebaNET/PruebaNET.API/appsettings.json" sustituimos el nombre del server colocado por el nombre de nuestro server y ejecutamos el proyecto:

```bash
  "ConnectionStrings": {
    "CadenaSQL": "Data Source=RVT-GT-JULIOGOM;Initial Catalog=PruebaNET;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=true;"
  }
```
- ### Configuración del frontend

Dentro de la carpeta "PruebaNETFront" ejecutamos en la terminal el comando:

```bash
  npm install
```

Al finalizar la instalación de los paquetes ejecutamos la aplicación:

```bash
  ng serve -o
```
