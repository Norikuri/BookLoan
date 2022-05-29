--�`�e�e�[�u���`--
--�������}�X�^�e�[�u��
CREATE TABLE department(
	--����ID
	id_department INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	--������
	nm_department VARCHAR(50) NOT NULL,
	--�X�V��
	id_update INT NOT NULL,
	--�X�V��
	date_update datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);

--���Ј��}�X�^�e�[�u��
CREATE TABLE employee(
	--���[�U�[ID
	id_employee INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	--���[�U�[��
	nm_employee VARCHAR(50) NOT NULL,
	--���[�U�[���ӂ肪��
	kn_employee VARCHAR(50) NOT NULL,
	--���[���A�h���X
	mail_address VARCHAR(100) UNIQUE NOT NULL,
	--�p�X���[�h
	password VARCHAR(10) NOT NULL,
	--����ID
	id_department INT NOT NULL,
	--�Ǘ��҃t���O(1�G�Ǘ��҂Q�G���)
	flg_admin CHAR(1) NOT NULL,
	--�ސE�t���O
	flg_retirement CHAR(1) NOT NULL,
	--�X�V��
	id_update INT NOT NULL,
	--�X�V��
	date_update TIMESTAMP NOT NULL,

	 FOREIGN KEY(id_department)
     REFERENCES department(id_department)

);

--�����Ѓ}�X�^�e�[�u��
CREATE TABLE books(
	--ISBN�R�[�h
	isbn VARCHAR(13) PRIMARY KEY NOT NULL,
	--���Ж�
	nm_book VARCHAR(50) NOT NULL,
	--���Ж����
	kn_book VARCHAR(100),
	--�o�Ŏ�
	publisher VARCHAR(50),
	--�X�V��
	id_update INT NOT NULL,
	--�X�V��
	date_update DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
);

--�������}�X�^�e�[�u��
CREATE TABLE book_collection(
	--����ID
	id_book INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	--ISBN
	isbn VARCHAR(13) NOT NULL,
	--���L����
	note TEXT,
	--�p���t���O(0:�ݏo�@1:�p��)
	fig_disposal CHAR(1) NOT NULL,
	--�X�V��
	id_update INT NOT NULL,
	--�X�V��
	date_update DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

	FOREIGN KEY(isbn)
    REFERENCES books(isbn)
);

--���ݏo�e�[�u��
CREATE TABLE borrow_books(
	--�\��ID
	id_request INT IDENTITY PRIMARY KEY NOT NULL,
	--�\����
	id_employee INT NOT NULL,
	--����ID
	id_book INT NOT NULL,
	--�\����
	date_request DATE NOT NULL,
	--�X�e�[�^�X(0:���F��/1:�ݏo��/2:�ݏo��/3:�ԋp��/9:�p��)
	status CHAR(1) NOT NULL,
	--���F��
	id_apporoval INT,
	--���F��
	date_approval DATE,
	--�ݏo��
	date_borrow DATE,
	--�ԋp�\���
	date DATE,
	--�ԋp��
	date_return DATE,
	--�X�V��
	id_update INT NOT NULL,
	--�X�V��
	date_update DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

	FOREIGN KEY(id_employee)
    REFERENCES employee(id_employee),

	FOREIGN KEY(id_book)
    REFERENCES book_collection(id_book),
);

-- �����e�[�u�������݂�����A���̃e�[�u�����폜����
DROP TABLE books IF EXISTS
--�m�F�p
SELECT * FROM books;

--�����̒ǉ��i�l�ވ琬���A�c�ƕ��A�Z�p���A�Ɩ��Ґ����A���Ɗ��{���j
INSERT INTO department(nm_department,id_update) VALUES('�l�ވ琬��',1);

INSERT INTO department(nm_department,id_update) VALUES('�c�ƕ�',1);
INSERT INTO department(nm_department,id_update) VALUES('�Z�p��',1);
INSERT INTO department(nm_department,id_update) VALUES('�Ɩ��Ґ���',1);
INSERT INTO department(nm_department,id_update) VALUES('���Ɗ�敔',1);

--��b�Ј��̒ǉ�
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('������O�Y','�Ȃ��͂��������Ԃ낤','nakaiku@thc.com','nai5343',1,1,0,1);

	INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
	VALUES('�������q�q','�������݂���','sugami@thc.com','you3822',1,1,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('�錴�s','�����͂�݂₱','suzumiya@thc.com','suo3921',2,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('�������O','�ɂ��͂炰�񂼂�','saigen@thc.com','hai9235',2,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('�����r�V��','�������������̂���','tasyun@thc.com','int0293',3,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('�đq��','��˂��炠����','yoneaka@thc.com','aoi8456',4,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('���c�m��','�ɂ����悤��','nishiyou@thc.com','kyk8322',5,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('���Y���O�Y','�������炰�񂴂Ԃ낤','sugen@thc.com','oiu7890',3,0,1,1);

--���Ѓ}�X�^�[�e�[�u���̒ǉ�
INSERT INTO books(isbn,nm_book,kn_book,publisher,id_update)
VALUES('9784807909896','�r�b�O�f�[�^������','�т����Ł[�����傤�ɂイ����','�������w���l',1);

INSERT INTO books(isbn,nm_book,kn_book,publisher,id_update)
VALUES('9784807909841','������120���y���ށI','���������ЂႭ�ɂ�����ρ[����Ƃ��̂��ށI','�������w���l',1);

INSERT INTO books(isbn,nm_book,kn_book,publisher,id_update)
VALUES('9784167104030','���̐l�̖��͌����Ȃ�','���̂ЂƂ̂Ȃ͂����Ȃ�','���Y�t�H',1);

SELECT * FROM book_collection

--�����}�X�^�e�[�u���̒ǉ�
INSERT�@INTO book_collection(isbn,note,fig_disposal,id_update)
VALUES('9784167104030','������������','1',1);

INSERT�@INTO book_collection(isbn,note,fig_disposal,id_update)
VALUES('9784807909841','�В�����̊�]�w���}��','0',1);

INSERT�@INTO book_collection(isbn,note,fig_disposal,id_update)
VALUES('9784807909896','���L�����Ȃ�','0',1);
