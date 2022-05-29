--～各テーブル～--
--※部署マスタテーブル
CREATE TABLE department(
	--部署ID
	id_department INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	--部署名
	nm_department VARCHAR(50) NOT NULL,
	--更新者
	id_update INT NOT NULL,
	--更新日
	date_update datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);

--※社員マスタテーブル
CREATE TABLE employee(
	--ユーザーID
	id_employee INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	--ユーザー名
	nm_employee VARCHAR(50) NOT NULL,
	--ユーザー名ふりがな
	kn_employee VARCHAR(50) NOT NULL,
	--メールアドレス
	mail_address VARCHAR(100) UNIQUE NOT NULL,
	--パスワード
	password VARCHAR(10) NOT NULL,
	--部署ID
	id_department INT NOT NULL,
	--管理者フラグ(1；管理者２；一般)
	flg_admin CHAR(1) NOT NULL,
	--退職フラグ
	flg_retirement CHAR(1) NOT NULL,
	--更新者
	id_update INT NOT NULL,
	--更新日
	date_update TIMESTAMP NOT NULL,

	 FOREIGN KEY(id_department)
     REFERENCES department(id_department)

);

--※書籍マスタテーブル
CREATE TABLE books(
	--ISBNコード
	isbn VARCHAR(13) PRIMARY KEY NOT NULL,
	--書籍名
	nm_book VARCHAR(50) NOT NULL,
	--書籍名よみ
	kn_book VARCHAR(100),
	--出版社
	publisher VARCHAR(50),
	--更新者
	id_update INT NOT NULL,
	--更新日
	date_update DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
);

--※蔵書マスタテーブル
CREATE TABLE book_collection(
	--蔵書ID
	id_book INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	--ISBN
	isbn VARCHAR(13) NOT NULL,
	--特記事項
	note TEXT,
	--廃棄フラグ(0:貸出可　1:廃棄)
	fig_disposal CHAR(1) NOT NULL,
	--更新者
	id_update INT NOT NULL,
	--更新日
	date_update DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

	FOREIGN KEY(isbn)
    REFERENCES books(isbn)
);

--※貸出テーブル
CREATE TABLE borrow_books(
	--申請ID
	id_request INT IDENTITY PRIMARY KEY NOT NULL,
	--申請者
	id_employee INT NOT NULL,
	--蔵書ID
	id_book INT NOT NULL,
	--申請日
	date_request DATE NOT NULL,
	--ステータス(0:承認待/1:貸出待/2:貸出中/3:返却済/9:却下)
	status CHAR(1) NOT NULL,
	--承認者
	id_apporoval INT,
	--承認日
	date_approval DATE,
	--貸出日
	date_borrow DATE,
	--返却予定日
	date DATE,
	--返却日
	date_return DATE,
	--更新者
	id_update INT NOT NULL,
	--更新日
	date_update DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

	FOREIGN KEY(id_employee)
    REFERENCES employee(id_employee),

	FOREIGN KEY(id_book)
    REFERENCES book_collection(id_book),
);

-- もしテーブルが存在したら、そのテーブルを削除する
DROP TABLE books IF EXISTS
--確認用
SELECT * FROM books;

--部署の追加（人材育成部、営業部、技術部、業務編成部、事業企画本部）
INSERT INTO department(nm_department,id_update) VALUES('人材育成部',1);

INSERT INTO department(nm_department,id_update) VALUES('営業部',1);
INSERT INTO department(nm_department,id_update) VALUES('技術部',1);
INSERT INTO department(nm_department,id_update) VALUES('業務編成部',1);
INSERT INTO department(nm_department,id_update) VALUES('事業企画部',1);

--基礎社員の追加
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('中畑育三郎','なかはたいくさぶろう','nakaiku@thc.com','nai5343',1,1,0,1);

	INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
	VALUES('菅原美智子','すがわらみちこ','sugami@thc.com','you3822',1,1,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('鈴原都','すずはらみやこ','suzumiya@thc.com','suo3921',2,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('西原源三','にしはらげんぞう','saigen@thc.com','hai9235',2,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('高橋俊之助','たかｈししゅんのすけ','tasyun@thc.com','int0293',3,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('米倉茜','よねくらあかね','yoneaka@thc.com','aoi8456',4,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('西田洋二','にしだようじ','nishiyou@thc.com','kyk8322',5,0,0,1);
INSERT INTO employee(nm_employee,kn_employee,mail_address,password,id_department,flg_admin,flg_retirement,id_update)
VALUES('杉浦源三郎','すぎうらげんざぶろう','sugen@thc.com','oiu7890',3,0,1,1);

--書籍マスターテーブルの追加
INSERT INTO books(isbn,nm_book,kn_book,publisher,id_update)
VALUES('9784807909896','ビッグデータ超入門','びっぐでーたちょうにゅうもん','東京化学同人',1);

INSERT INTO books(isbn,nm_book,kn_book,publisher,id_update)
VALUES('9784807909841','お酒を120％楽しむ！','おさけをひゃくにじゅっぱーせんとたのしむ！','東京化学同人',1);

INSERT INTO books(isbn,nm_book,kn_book,publisher,id_update)
VALUES('9784167104030','その人の名は言えない','そのひとのなはいえない','文藝春秋',1);

SELECT * FROM book_collection

--蔵書マスタテーブルの追加
INSERT　INTO book_collection(isbn,note,fig_disposal,id_update)
VALUES('9784167104030','汚損多数あり','1',1);

INSERT　INTO book_collection(isbn,note,fig_disposal,id_update)
VALUES('9784807909841','社長からの希望購入図書','0',1);

INSERT　INTO book_collection(isbn,note,fig_disposal,id_update)
VALUES('9784807909896','特記事項なし','0',1);
