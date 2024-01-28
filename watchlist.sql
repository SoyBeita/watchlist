-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-01-2024 a las 23:50:43
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `watchlist`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista_peliculas_series`
--

CREATE TABLE `lista_peliculas_series` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `nombre_lista` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `lista_peliculas_series`
--

INSERT INTO `lista_peliculas_series` (`id`, `id_usuario`, `nombre_lista`) VALUES
(1, 1, 'Películas de terror'),
(2, 1, 'K-dramas'),
(3, 1, 'Series favoritas'),
(4, 3, 'Películas románticas'),
(5, 3, 'Series que quiero ver'),
(6, 4, 'Películas de acción'),
(7, 4, 'Películas recomendadas'),
(8, 5, 'Series de dibujos'),
(9, 5, 'Documentales'),
(11, 1, 'Amor');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `peliculas`
--

CREATE TABLE `peliculas` (
  `id` int(11) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `descripcion` varchar(250) DEFAULT NULL,
  `Genero` varchar(50) NOT NULL,
  `Fecha` int(10) NOT NULL,
  `caratula` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `peliculas`
--

INSERT INTO `peliculas` (`id`, `nombre`, `descripcion`, `Genero`, `Fecha`, `caratula`) VALUES
(2, 'Los Otros', 'Mientras espera que su marido regrese de la II Guerra Mundial, una devota cristiana con dos hijos empieza a sospechar que su caserón familiar está encantado.', 'Terror', 2001, 'https://pics.filmaffinity.com/los_otros_the_others-255113377-msmall.jpg'),
(3, 'Déjame salir', 'Chris está ansioso por conocer a los padres de su novia Rose, y sus nervios resultan justificados cuando la reunión pasa a ser de incómoda a terrorífica.', 'Terror', 2017, 'https://pics.filmaffinity.com/get_out-290175782-mmed.jpg'),
(4, 'Annabelle', 'Años después de la muerte de su hija, un fabricante de muñecas y su mujer abren su casa a varias huérfanas, que pronto empiezan a temer a una de sus horribles creaciones.', 'Terror', 2014, 'https://pics.filmaffinity.com/annabelle-671994408-mmed.jpg'),
(5, 'Los juegos del hambre', 'En un futuro distópico, Katniss y Peeta participan en un evento televisado en el que los jóvenes luchan unos contra otros hasta la muerte.', 'Accion', 2012, 'https://pics.filmaffinity.com/the_hunger_games-593958523-mmed.jpg'),
(6, 'Tenet', 'Un agente encubierto debe recuperar una misteriosa y poderosa arma para detener una guerra temporal que podría destruir el mundo', 'Accion', 2020, 'https://pics.filmaffinity.com/tenet-432994986-mmed.jpg'),
(7, 'Nerve', 'Ella pensaba que el juego en línea en el que se acababa de inscribir era inofensivo. Ahora, solo ganando logrará salir de allí', 'Accion', 2016, 'https://pics.filmaffinity.com/nerve-310845581-mmed.jpg'),
(8, 'Pretty Woman', 'Tras llegar a un acuerdo con Vivian, una prostituta de Hollywood, para que pase una semana con él, el estirado magnate de los negocios Edward acaba perdiendo el corazón', 'Romantica', 1990, 'https://pics.filmaffinity.com/pretty_woman-629528349-mmed.jpg'),
(9, 'Guerra de novias', 'Emma y su mejor amiga Liv siempre han soñado con celebrar sus bodas en un exclusivo hotel. Pero cuando les dan la misma fecha, ninguna está dispuesta a renunciar.', 'Romantica', 2009, 'https://pics.filmaffinity.com/bride_wars-685733332-mmed.jpg'),
(10, 'Jurassic Park', 'Ciencia, sabotaje y ADN prehistórico. Se desata el caos cuando los dinosaurios clonados de un parque temático escapan y convierten a los visitantes en sus presas.', 'ciencia ', 1993, 'https://pics.filmaffinity.com/jurassic_park-187298880-mmed.jpg');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `peliculas_series`
--

CREATE TABLE `peliculas_series` (
  `id` int(11) NOT NULL,
  `id_lista_peliculas_series` int(11) DEFAULT NULL,
  `id_peliculas` int(11) DEFAULT NULL,
  `id_series` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `peliculas_series`
--

INSERT INTO `peliculas_series` (`id`, `id_lista_peliculas_series`, `id_peliculas`, `id_series`) VALUES
(1, 1, 3, NULL),
(2, 1, 2, NULL),
(3, 2, NULL, 2),
(4, 2, NULL, 1),
(5, 9, NULL, 10),
(6, 6, 5, NULL),
(7, 7, 6, NULL),
(8, 3, NULL, 5),
(9, 3, NULL, 3),
(10, 4, 8, NULL),
(11, 5, NULL, 7),
(12, 8, NULL, 8),
(13, 8, NULL, 9),
(21, 11, 8, NULL),
(23, 11, 9, NULL),
(24, 11, NULL, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `series`
--

CREATE TABLE `series` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(300) DEFAULT NULL,
  `Genero` varchar(50) NOT NULL,
  `fecha` int(10) NOT NULL,
  `caratula` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `series`
--

INSERT INTO `series` (`id`, `nombre`, `descripcion`, `Genero`, `fecha`, `caratula`) VALUES
(1, 'My Holo Love', 'El exclusivo prototipo Holo aparece en la vida de la solitaria Han So-Yeon, con la intención de ayudarla en todo lo que necesite, siempre que ella lo permita', 'coreana', 2020, 'https://pics.filmaffinity.com/my_holo_love-281767192-mmed.jpg'),
(2, 'Love alarm', 'A diferencia de sus amigos, Kim Jojo tiene cosas más importantes en la cabeza que tener pareja. ', 'coreana', 2019, 'https://pics.filmaffinity.com/love_alarm_joahamyeon_ullineun-258915835-mmed.jpg'),
(3, 'Propuesta laboral', 'Ha-ri se hace pasar por su amiga durante una cita a ciegas para ahuyentar a su pretendiente. Pero el plan cambia cuando este resulta ser su CEO, que le hace una propuesta. ', 'coreana', 2022, 'https://pics.filmaffinity.com/business_proposal-459472764-mmed.jpg'),
(4, 'La casa de papel', 'Ocho atracadores toman rehenes en la Fábrica Nacional de Moneda y Timbre española. Desde el encierro, si líder manipula a la policía para llevar a cabo un ambicioso plan.', 'española', 2017, 'https://pics.filmaffinity.com/la_casa_de_papel-844739080-mmed.jpg'),
(5, 'Aquí no hay quien viva', 'Se narra la vida de una peculiar comunidad de vecinos en la ficticia calle Desengaño 21.', 'española', 2003, 'https://pics.filmaffinity.com/aqui_no_hay_quien_viva-150319925-mmed.jpg'),
(6, 'Paquita Salas', 'Paquita salas es una de las mejores representantes de actores de España de los 90. Dirige PS Management y cuenta con la actriz Macarena García entre sus representados.', 'española', 2016, 'https://pics.filmaffinity.com/paquita_salas-246815366-mmed.jpg'),
(7, 'Hora de aventuras', 'El joven Finn y su amigo Jake, un perro capaz de adoptar formas diferentes, viven todo tipo de aventuras surrealistas mientras atraviesan el postapocalíptico País de Ooo.', 'dibujos', 2010, 'https://pics.filmaffinity.com/adventure_time_with_finn_jake-507797147-mmed.jpg'),
(8, 'Las super nenas', 'Las encantadores hermanas Pétalo, Burbuja y Cactus se dedican a salvar el mundo de las garras del crimen y las fuerzas del mal.', 'dibujos', 1998, 'https://pics.filmaffinity.com/the_powerpuff_girls-345908999-mmed.jpg'),
(9, 'Peppa Pig', 'Una familia de cerditos que ayudarán a los más pequeños de la casa a conocer el mundo que les rodea.', 'dibujos', 2004, 'https://pics.filmaffinity.com/peppa_pig-875024597-mmed.jpg'),
(10, 'La vida en nuestro planeta', 'Esta serie sobre naturaleza narra cómo ha evolucionado la vida para conquistar, adaptarse y sobrevivir en la Tierra a lo largo de miles de millones de años', 'documental', 2023, 'https://pics.filmaffinity.com/life_on_our_planet-801684016-mmed.jpg');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `usuario` varchar(25) NOT NULL,
  `pass` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `usuario`, `pass`) VALUES
(1, 'Bea', '1234'),
(3, 'Laura', '12345'),
(4, 'Carlos', '123'),
(5, 'Siri', '0000');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `lista_peliculas_series`
--
ALTER TABLE `lista_peliculas_series`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- Indices de la tabla `peliculas`
--
ALTER TABLE `peliculas`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `peliculas_series`
--
ALTER TABLE `peliculas_series`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_lista_peliculas_series` (`id_lista_peliculas_series`),
  ADD KEY `id_peliculas` (`id_peliculas`),
  ADD KEY `id_series` (`id_series`);

--
-- Indices de la tabla `series`
--
ALTER TABLE `series`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `lista_peliculas_series`
--
ALTER TABLE `lista_peliculas_series`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `peliculas`
--
ALTER TABLE `peliculas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `peliculas_series`
--
ALTER TABLE `peliculas_series`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `series`
--
ALTER TABLE `series`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `lista_peliculas_series`
--
ALTER TABLE `lista_peliculas_series`
  ADD CONSTRAINT `lista_peliculas_series_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`);

--
-- Filtros para la tabla `peliculas_series`
--
ALTER TABLE `peliculas_series`
  ADD CONSTRAINT `peliculas_series_ibfk_1` FOREIGN KEY (`id_lista_peliculas_series`) REFERENCES `lista_peliculas_series` (`id`),
  ADD CONSTRAINT `peliculas_series_ibfk_2` FOREIGN KEY (`id_peliculas`) REFERENCES `peliculas` (`id`),
  ADD CONSTRAINT `peliculas_series_ibfk_3` FOREIGN KEY (`id_series`) REFERENCES `series` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
