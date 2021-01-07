create database nombre;

use nombre;



delete nombre;

create table usuario(

	idUsuario int primary key identity,
	nombreUsuario varchar(50),
	passwordUsuario varchar(50),
	emailusuario varchar(50)

);

create table libros(

	idLibro int primary key,
	tituloLibro varchar(50),
	autorLibro varchar(50),
	precioLibro int,
	
);

create table cliente(

	idCliente int primary key,
	nombreCliente varchar(50),
	apellidoCliente varchar(50),
	telefonoCliente int,
	miembro varchar(2)

);

create table prestados(
	
	idPrestamo int primary key,
	idLibro int,
	idCliente int,
	fechaPrestado date,
	fechaRetornado date,
	vendido varchar(2),
	
);

create table retornar(
	
	idRetorno int primary key,
	idPrestamo int,
	idLibro int,
	idCliente int,
	fechaRetornado date,
	multa int,

);

select * from usuario;
select * from libros;
select * from cliente;
select * from prestados;
select * from retornar;

drop table usuario;
drop table libros;
drop table cliente;
drop table prestados;
drop table retornar;

