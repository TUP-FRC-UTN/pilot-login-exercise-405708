CREATE DATABASE pilotLogin
USE pilotLogin

CREATE TABLE Paises(
    idPais int IDENTITY(1,1),
    pais varchar(60)
    CONSTRAINT pk_pais PRIMARY KEY(idPais)
);

CREATE TABLE Pilotos(
    idPiloto int IDENTITY(1,1),
    nombre varchar(40),
	cant_hr_vuelo int,
	email varchar(40),
    pais int,
    CONSTRAINT pk_piloto PRIMARY KEY (idPiloto),
    CONSTRAINT fk_pais FOREIGN KEY (pais)
        REFERENCES Paises(idPais)
);

CREATE TABLE Users(
    userId int IDENTITY(1,1),
    userEmail varchar(100) NOT NULL,
    password varchar(100) NOT NULL
);

INSERT INTO Users(userEmail,[password]) VALUES('tup2022@tup.com.ar','123456');
INSERT INTO Paises (pais) VALUES ('Argentina'), ('Uruguay'), ('Chile');