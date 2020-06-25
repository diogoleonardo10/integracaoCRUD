--
-- PostgreSQL database dump
--

-- Dumped from database version 12.0
-- Dumped by pg_dump version 12.0

-- Started on 2020-06-24 23:54:32

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 205 (class 1259 OID 40978)
-- Name: movimento; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.movimento (
    movi_id integer NOT NULL,
    movi_data timestamp with time zone,
    movi_descricao character varying,
    movi_proc_id integer
);


ALTER TABLE public.movimento OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 40976)
-- Name: movimento_movi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.movimento_movi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movimento_movi_id_seq OWNER TO postgres;

--
-- TOC entry 2836 (class 0 OID 0)
-- Dependencies: 204
-- Name: movimento_movi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.movimento_movi_id_seq OWNED BY public.movimento.movi_id;


--
-- TOC entry 203 (class 1259 OID 40967)
-- Name: processos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.processos (
    proc_id integer NOT NULL,
    proc_grau character varying,
    proc_num character varying
);


ALTER TABLE public.processos OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 40965)
-- Name: processos_proc_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.processos_proc_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.processos_proc_id_seq OWNER TO postgres;

--
-- TOC entry 2837 (class 0 OID 0)
-- Dependencies: 202
-- Name: processos_proc_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.processos_proc_id_seq OWNED BY public.processos.proc_id;


--
-- TOC entry 2696 (class 2604 OID 40981)
-- Name: movimento movi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movimento ALTER COLUMN movi_id SET DEFAULT nextval('public.movimento_movi_id_seq'::regclass);


--
-- TOC entry 2695 (class 2604 OID 40970)
-- Name: processos proc_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.processos ALTER COLUMN proc_id SET DEFAULT nextval('public.processos_proc_id_seq'::regclass);


--
-- TOC entry 2830 (class 0 OID 40978)
-- Dependencies: 205
-- Data for Name: movimento; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.movimento (movi_id, movi_data, movi_descricao, movi_proc_id) FROM stdin;
1	2020-06-23 00:00:00-03	Teste movimentacao	1
\.


--
-- TOC entry 2828 (class 0 OID 40967)
-- Dependencies: 203
-- Data for Name: processos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.processos (proc_id, proc_grau, proc_num) FROM stdin;
6	7	77777
2	4	0056830.28.2017
1	3	5227273.70.2018
5	6	0165377.82.2017
\.


--
-- TOC entry 2838 (class 0 OID 0)
-- Dependencies: 204
-- Name: movimento_movi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.movimento_movi_id_seq', 1, false);


--
-- TOC entry 2839 (class 0 OID 0)
-- Dependencies: 202
-- Name: processos_proc_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.processos_proc_id_seq', 6, true);


--
-- TOC entry 2700 (class 2606 OID 40983)
-- Name: movimento movimento_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movimento
    ADD CONSTRAINT movimento_pkey PRIMARY KEY (movi_id);


--
-- TOC entry 2698 (class 2606 OID 40975)
-- Name: processos processos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.processos
    ADD CONSTRAINT processos_pkey PRIMARY KEY (proc_id);


-- Completed on 2020-06-24 23:54:32

--
-- PostgreSQL database dump complete
--

