--
-- PostgreSQL database dump
--

-- Dumped from database version 16.8 (Ubuntu 16.8-0ubuntu0.24.04.1)
-- Dumped by pg_dump version 16.8 (Ubuntu 16.8-0ubuntu0.24.04.1)

-- Started on 2025-05-18 23:12:28 MSK

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2 (class 3079 OID 49165)
-- Name: pgcrypto; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS pgcrypto WITH SCHEMA public;


--
-- TOC entry 3442 (class 0 OID 0)
-- Dependencies: 2
-- Name: EXTENSION pgcrypto; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION pgcrypto IS 'cryptographic functions';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 216 (class 1259 OID 49153)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    guid uuid DEFAULT gen_random_uuid() NOT NULL,
    login character varying(50) NOT NULL,
    password character varying(100) NOT NULL,
    name character varying(100) NOT NULL,
    gender integer NOT NULL,
    birthday date,
    admin boolean DEFAULT false NOT NULL,
    createdon timestamp without time zone NOT NULL,
    createdby character varying(50) NOT NULL,
    modifiedon timestamp without time zone NOT NULL,
    modifiedby character varying(50) NOT NULL,
    revokedon timestamp without time zone,
    revokedby character varying(50),
    CONSTRAINT users_gender_check CHECK ((gender = ANY (ARRAY[0, 1, 2]))),
    CONSTRAINT users_login_check CHECK (((login)::text ~ '^[A-Za-z0-9]+$'::text)),
    CONSTRAINT users_name_check CHECK (((name)::text ~ '^[A-Za-zЂ-џ -прс]+$'::text)),
    CONSTRAINT users_password_check CHECK (((password)::text ~ '^[A-Za-z0-9]+$'::text))
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 3436 (class 0 OID 49153)
-- Dependencies: 216
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--
--
-- TOC entry 3290 (class 2606 OID 49164)
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- TOC entry 3292 (class 2606 OID 49162)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (guid);


-- Completed on 2025-05-18 23:12:32 MSK

--
-- PostgreSQL database dump complete
--

