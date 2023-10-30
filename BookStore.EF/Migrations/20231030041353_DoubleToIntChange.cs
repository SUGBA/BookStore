using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class DoubleToIntChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumns: new[] { "BookEntityId", "DepartmentEntityId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Books",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "Name", "PageCount", "PathToImage", "Price" },
                values: new object[,]
                {
                    { 1, (byte)2, "Граф Аверин. Колдун Российской империи", 320, "/images/catalogImages/1.jpg", 550.0 },
                    { 2, (byte)4, "Портрет Дориана Грея", 480, "/images/catalogImages/2.jpg", 690.0 },
                    { 3, (byte)1, "Ваш покорный слуга кот", 120, "/images/catalogImages/3.jpg", 480.0 },
                    { 4, (byte)1, "1984 (новый перевод)", 370, "/images/catalogImages/4.jpg", 550.0 },
                    { 5, (byte)2, "Триумфальная арка", 390, "/images/catalogImages/9.jpg", 440.0 },
                    { 6, (byte)2, "На Западном фронте без перемен", 280, "/images/catalogImages/5.jpg", 500.0 },
                    { 7, (byte)1, "Грозовой перевал", 410, "/images/catalogImages/6.jpg", 380.0 },
                    { 8, (byte)2, "Клуб самоубийц", 410, "/images/catalogImages/7.jpg", 570.0 },
                    { 9, (byte)4, "Мартин Иден", 380, "/images/catalogImages/8.jpg", 410.0 },
                    { 10, (byte)4, "Маленький принц", 230, "/images/catalogImages/10.jpg", 600.0 },
                    { 11, (byte)5, "Отцы и дети", 510, "/images/catalogImages/11.jpg", 380.0 },
                    { 12, (byte)3, "Работа легкой не бывает", 300, "/images/catalogImages/12.jpg", 750.0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Mail", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "khabfafkjhb@gmail.com", "Валиев Антон Дмитриевич", "898249553535" },
                    { 2, "akjbfkabfjhabf@gmail.com", "Полынский Арсений Андреевич", "898005553536" },
                    { 3, "1894bafbahfbj@gmail.com", "Рогожников Даниил Владимирович", "898005553535" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "DateCreate", "PathToImage" },
                values: new object[,]
                {
                    { 1, "Сентябрь 2023. Выпуск №3 Это интересно 1. Литературный тиндер: любовь в советскую и постсоветскую эпохи. Мы пофантазировали о том, как выглядели бы профили персонажей советских и современных российских писателей в дейтингах, и как сложились бы их отношения, если они нашли бы друг друга именно там. 2. Что мир читал в 1865 году? Пришествие Алисы и полет на Луну. В этом году читателю выпало свести знакомство с целым рядом очень интересных книг самого разного жанра. И с целым рядом авторов, о которых он раньше и не слышал. 3. Почему из «Смертельного образования» получилось бы классное аниме. Смертельно опасная школа волшебников, подростки", new DateTime(2023, 10, 18, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7320), "/images/newsImages/1.jpg" },
                    { 2, "В день рождения великого языковеда Сергея Ивановича Ожегова, составителя одного из самых популярных толковых словарей, мы с вами ненадолго перенесемся в прошлое и проверим знание старинных или вышедших из употребления слов. Пройти тест", new DateTime(2023, 10, 17, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7327), "/images/newsImages/2.jpg" },
                    { 3, "В современном мире множество причин для тревог: нелюбимая работа, вынужденный переезд, утрата  близких... Неисчерпаемый колодезь личных проблем — неспособность принять себя, синдром самозванца, страх совершить ошибку и многое, многое другое. Новая книга психолога Ольги Примаченко, автора бестселлера «К себе нежно», послужит лекарством для ран и тревог. Конечно, нет универсального рецепта для всех на свете проблем, зато можно научиться верить себе, спокойно воспринимать окружающий мир и строить жизнь так, как хочется нам, а не так, как диктуют другие. Ольга Примаченко - Всё закончится, а ты нет. ", new DateTime(2023, 10, 16, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7328), "/images/newsImages/3.jpg" },
                    { 4, "С прошлого ноября, как и каждый предыдущий год, Шведская академия получает тысячи писем в поддержку авторов, как признанных, так и малоизвестных, претендующих на Нобелевскую премию. Такие номинации могут быть сделаны только квалифицированными номинаторами. Кто обладает правом номинировать кандидатов на Нобелевскую премию: 1. Члены Шведской академии и других академий, институтов и обществ, сходных с ней по структуре и назначению. 2. Профессора литературы и лингвистики в университетах и колледжах. 3. Предыдущие лауреаты Нобелевской премии по литературе.", new DateTime(2023, 10, 15, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7329), "/images/newsImages/4.jpg" },
                    { 5, "Сегодня признанному Королю Ужасов исполняется 76 лет, и мы попросили нашего колумниста Энджи Эфенди раскрыть тайны такой притягательности прозы этого великого автора. Впервые я прочитала рассказ Кинга в девять лет в «Антологии современного американского рассказа». Никак не ожидала от смирной советской книжки, где обычно печатались истории с социальным подтекстом, и от рассказа с милым названием «Дети кукурузы» такой подставы. Потом уже стали появляться на прилавках книги Кинга в жутковатых (но креативных) обложках 90-х годов, и я узнала, насколько популярный он автор.", new DateTime(2023, 10, 14, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7330), "/images/newsImages/5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "user1", "User1", "user1", (byte)2 },
                    { 2, "user2", "User2", "user2", (byte)2 },
                    { 3, "user3", "User3", "user3", (byte)2 },
                    { 4, "admin1", "Admin1", "admin1", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Address", "ManagerEntityId" },
                values: new object[,]
                {
                    { 1, "Цемлянская, 23", 1 },
                    { 2, "Братская, 77", 2 },
                    { 3, "Ленина, 12", 3 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "BookEntityId", "DepartmentEntityId", "BookCount" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 4, 1, 18 },
                    { 7, 1, 57 },
                    { 10, 1, 14 },
                    { 2, 2, 30 },
                    { 5, 2, 99 },
                    { 8, 2, 58 },
                    { 11, 2, 15 },
                    { 3, 3, 27 },
                    { 6, 3, 56 },
                    { 9, 3, 12 },
                    { 12, 3, 3 }
                });
        }
    }
}
