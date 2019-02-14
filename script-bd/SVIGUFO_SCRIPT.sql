-- DOCUMENTA�AO https://docs.microsoft.com/pt-br/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-2017
/*CRIA��O DO BANCO DE DADOS*/
CREATE DATABASE SENAI_SVIGUFO_APACHE;

--USAR O BANCO DE DADOS <NOME BANCO>
USE SENAI_SVIGUFO_APACHE;

--CRIA TABELA TIPO DE EVENTOS
--MYSQL - AUTO INCREMENT
-- IDENTITY - AUTO INCREMENTA O VALOR PARA CADA REGISTRO INSERIDO
-- PRIMARY KEY - DEFINE QUE O CAMPO � CHAVE PRIM�RIA
-- UNIQUE - REGISTROS UNICOS, N�O DEIXA INSERIR UM DADO COM O MESMO VALOR
-- NOT NULL - N�O PERMITE CAMPOS NULOS
CREATE TABLE TIPOS_EVENTOS (
	ID INT IDENTITY PRIMARY KEY 
	,TITULO VARCHAR(250) UNIQUE NOT NULL    
); 

CREATE TABLE INSTITUICOES (
	ID INT IDENTITY PRIMARY KEY 
	, NOME_FANTASIA VARCHAR(250) NULL
	, RAZAO_SOCIAL VARCHAR(250) NOT NULL
	, CNPJ CHAR(14) NOT NULL UNIQUE 
	, LOGRADOURO VARCHAR(200) NOT NULL 
	, CEP CHAR(8) NOT NULL
	, UF CHAR(2) NOT NULL
	, CIDADE VARCHAR(200) NOT NULL
);

CREATE TABLE EVENTOS (
	ID INT IDENTITY PRIMARY KEY
	,TITULO VARCHAR(250) NOT NULL 
	,DESCRICAO TEXT NOT NULL  
	,DATA_EVENTO DATETIME NOT NULL
	-- 1 ACESSO P�BLICO, 0 ACESSO RESTRITO
	,ACESSO_LIVRE BIT DEFAULT (1)
	,ID_INSTITUICAO INT  
	,ID_TIPO_EVENTO INT
	--DEFINE AS CHAVES ESTRANGEIRAS, REFERENCIA A TABELA
	,FOREIGN KEY (ID_INSTITUICAO) REFERENCES INSTITUICOES(ID)
	,FOREIGN KEY (ID_TIPO_EVENTO) REFERENCES TIPOS_EVENTOS(ID)
);

CREATE TABLE USUARIOS(
	ID INT IDENTITY PRIMARY KEY
	,NOME VARCHAR (255) NOT NULL
	,EMAIL VARCHAR(250) NOT NULL UNIQUE
	,SENHA VARCHAR(100) NOT NULL
	,TIPO_USUARIO VARCHAR(50) NOT NULL
);

CREATE TABLE CONVITES(
	ID INT IDENTITY PRIMARY KEY
	,ID_EVENTO INT NOT NULL FOREIGN KEY REFERENCES EVENTOS(ID)
	,ID_USUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIOS(ID)
	,SITUACAO CHAR(1) DEFAULT (1)
);	

insert into TIPOS_EVENTOS values ('Tecnologia')