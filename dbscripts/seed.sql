\connect inventario

DROP TABLE IF EXISTS tbl_empleado
DROP TABLE IF EXISTS tbl_area
DROP TABLE IF EXISTS tbl_producto
DROP TABLE IF EXISTS tbl_estado
DROP TABLE IF EXISTS tbl_tipo_producto
DROP TABLE IF EXISTS tbl_proveedor
DROP TABLE IF EXISTS tbl_inventario

CREATE TABLE tbl_empleado (id_empleado serial NOT NULL, nombre character varying(20) NOT NULL, DNI character varying(10),id_area integer NULL, CONSTRAINT empleado_pk PRIMARY KEY(id_empleado));
CREATE TABLE tbl_area (id_area serial NOT NULL, nombre character varying(20) NOT NULL, descripcion character varying(200), CONSTRAINT area_pk PRIMARY KEY (id_area));
CREATE TABLE tbl_producto (id_producto serial NOT NULL, nombre character varying(20) NOT NULL, descripcion character varying(200),valor decimal(18,2),id_proveedor integer NOT NULL,id_tipo_producto integer NOT NULL, CONSTRAINT producto_pk PRIMARY KEY(id_producto));
CREATE TABLE tbl_estado (id_estado serial NOT NULL, nombre character varying(20) NOT NULL, descripcion character varying(200),CONSTRAINT estado_pk PRIMARY KEY (id_estado));
CREATE TABLE tbl_tipo_producto (id_tipo_producto serial NOT NULL, nombre character varying(20) NOT NULL, descripcion character varying(200),CONSTRAINT tipo_producto_pk PRIMARY KEY (id_tipo_producto));
CREATE TABLE tbl_proveedor (id_proveedor serial NOT NULL, nombre character varying(20) NOT NULL, nit character varying(20) NOT NULL, telefono character varying(20) NULL, correo character varying(50) NULL,CONSTRAINT proveedor_pk PRIMARY KEY (id_proveedor));
CREATE TABLE tbl_inventario (id_inventario serial NOT NULL, codigo_serial character varying(20) NOT NULL, fecha date, observaciones character varying(500),id_producto integer NOT NULL, id_empleado integer NULL, id_area integer NULL, id_estado integer NOT NULL,CONSTRAINT inventario_pk PRIMARY KEY (id_inventario));

ALTER TABLE public.tbl_area    
  OWNER TO admin; 
ALTER TABLE public.tbl_empleado    
  OWNER TO admin; 
ALTER TABLE public.tbl_estado    
  OWNER TO admin; 
ALTER TABLE public.tbl_inventario    
  OWNER TO admin; 
 ALTER TABLE public.tbl_producto    
  OWNER TO admin; 
 ALTER TABLE public.tbl_proveedor    
  OWNER TO admin; 
ALTER TABLE public.tbl_tipo_producto    
  OWNER TO admin; 

ALTER TABLE tbl_inventario ADD CONSTRAINT fk_empleado FOREIGN KEY(id_empleado) REFERENCES tbl_empleado(id_empleado);
ALTER TABLE tbl_inventario ADD CONSTRAINT fk_area FOREIGN KEY(id_area) REFERENCES tbl_area(id_area);
ALTER TABLE tbl_inventario ADD CONSTRAINT fk_producto FOREIGN KEY(id_producto) REFERENCES tbl_producto(id_producto);
ALTER TABLE tbl_inventario ADD CONSTRAINT fk_estado FOREIGN KEY(id_estado) REFERENCES tbl_estado(id_estado);
ALTER TABLE tbl_producto ADD CONSTRAINT fk_proveedor FOREIGN KEY(id_proveedor) REFERENCES tbl_proveedor(id_proveedor);
ALTER TABLE tbl_producto ADD CONSTRAINT fk_tipo_producto FOREIGN KEY(id_tipo_producto) REFERENCES tbl_tipo_producto(id_tipo_producto);
ALTER TABLE tbl_empleado ADD CONSTRAINT fk_id_area FOREIGN KEY(id_area) REFERENCES tbl_area(id_area);

INSERT INTO tbl_tipo_producto(nombre, descripcion) VALUES ('tecnológico','Se refiere a computadores, impresoras, monitores etc');
INSERT INTO tbl_tipo_producto(nombre, descripcion) VALUES ('miscelaneo','Se refiere a insumos de oficina');	
INSERT INTO tbl_tipo_producto(nombre, descripcion) VALUES ('inmueble','Se refiere a bienes activos');	

INSERT INTO tbl_estado(nombre,descripcion) VALUES ('activo','producto funcional y activo');
INSERT INTO tbl_estado(nombre,descripcion) VALUES ('reparacion','producto está en proceso de repación');
INSERT INTO tbl_estado(nombre,descripcion) VALUES ('no funcional','producto dañado');

INSERT INTO tbl_proveedor (nombre, nit, telefono, correo) VALUES ('samsung','80.852.744-9','(+057) 4844-345','samsung@sg.com');
INSERT INTO tbl_proveedor (nombre, nit, telefono, correo) VALUES ('panamericana','76.832.744-9','(+057) 5678-345','panamericanag@pn.com');
INSERT INTO tbl_proveedor (nombre, nit, telefono, correo) VALUES ('rimax','52.852.748-0','(+057) 7895-345','rimax@rm.com');
INSERT INTO tbl_proveedor (nombre, nit, telefono, correo) VALUES ('LG','40.852.744-4','(+057) 8524-345','lg@lg.com');

INSERT INTO tbl_area(nombre,descripcion) VALUES ('financiera','facturaciones');
INSERT INTO tbl_area(nombre,descripcion) VALUES ('recursos humanos','contrataciones y bienestar');
INSERT INTO tbl_area(nombre,descripcion) VALUES ('gerencia','jefe de proyecto o área');
INSERT INTO tbl_area(nombre,descripcion) VALUES ('administrativa','nómina y presupuesto');

INSERT INTO tbl_empleado (nombre, DNI,id_area) VALUES ('elmo rocero','80852369',1);
INSERT INTO tbl_empleado (nombre, DNI,id_area) VALUES ('rosalba dora','1025987963',2);
INSERT INTO tbl_empleado (nombre, DNI,id_area) VALUES ('elvira sánchez','81852987',2);
INSERT INTO tbl_empleado (nombre, DNI,id_area) VALUES ('edmund gutierrez','75894652',3);
INSERT INTO tbl_empleado (nombre, DNI,id_area) VALUES ('timi otul','1123123123',4);

INSERT INTO tbl_producto (nombre, descripcion,valor,id_proveedor,id_tipo_producto) VALUES ('Samsung Galaxy Tab','tablet',4500000,1,1);
INSERT INTO tbl_producto (nombre, descripcion,valor,id_proveedor,id_tipo_producto) VALUES ('resma de papel','fotocopiadora',25000,2,2);
INSERT INTO tbl_producto (nombre, descripcion,valor,id_proveedor,id_tipo_producto) VALUES ('silla','cocina',50000,3,3);
INSERT INTO tbl_producto (nombre, descripcion,valor,id_proveedor,id_tipo_producto) VALUES ('Monitor','sala de juntas',450000,4,1);

INSERT INTO tbl_inventario (codigo_serial, fecha, observaciones, id_producto, id_empleado, id_area, id_estado) VALUES ('1S1234',NOW(),'',1,1,1,1);
INSERT INTO tbl_inventario (codigo_serial, fecha, observaciones, id_producto, id_empleado, id_area, id_estado) VALUES ('1S1235',NOW(),'',2,2,1,1);
INSERT INTO tbl_inventario (codigo_serial, fecha, observaciones, id_producto, id_empleado, id_area, id_estado) VALUES ('1S1236',NOW(),'',3,3,2,1);
INSERT INTO tbl_inventario (codigo_serial, fecha, observaciones, id_producto, id_empleado, id_area, id_estado) VALUES ('1S1237',NOW(),'',4,4,3,1);


