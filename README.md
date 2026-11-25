# نظام إدارة المدرسة (School Management System)

تطبيق ويب بنمط MVC لإدارة الطلاب والمعلمين والمقررات والفصول، وتسجيل الطلاب في المقررات. مبني بـ ASP.NET Core وEntity Framework Core وSQL Server.

## ماذا يفعل المشروع؟
- إضافة وعرض وتعديل وحذف الطلاب والمعلمين والمقررات والفصول.
- تسجيل الطالب في مقرر عبر جدول وسيط (`StudentCourse`).
- ربط كل مقرر بمعلم.
- تحقق من المدخلات (طول الاسم، حدود العمر والسعة) وحفظ اسم صورة الطالب.

## البنية
- `Controllers`: متحكم لكل كيان.
- `Repository`: واجهة ومستودع لكل كيان (Repository Pattern).
- `Context/MyDbContext`: سياق قاعدة البيانات، مع Migrations.

## التشغيل
1. عدّل سلسلة الاتصال `MyConnection` في `SchoolProject/appsettings.json`.
2. نفّذ `dotnet ef database update`.
3. نفّذ `dotnet run --project SchoolProject`.

## ملاحظة
صمّمتُ المشروع وطوّرته بمساعدة أدوات ذكاء اصطناعي، وأقدر أشرح كل جزء فيه.
