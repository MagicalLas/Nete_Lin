# Create

Create는 테이블을 생성하는 명령어이다. DDL이라고 분류되는데 초기에만 잠깐 사용이 된다. 어차피 데이터베이스를 계속 생성 할 이유는 없기 때문에 그렇다.

## 예시
```sql
create table 테이블이름 (속성이름 int NOT NULL,
    이름 varchar(10) DEFAULT 'username',
    이름2 varchar(10) DEFAULT 'username',
    PRIMARY KEY(이름,속성이름)
)
```