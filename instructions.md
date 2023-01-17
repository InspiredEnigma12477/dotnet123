npx create-react-app client
dotnet new sln
dotnet new webapi -n server
cd server
dotnet add package mysql.data
dotnet add package Microsoft.AspNetCore.Cors --version 2.20
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.17 
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.17 
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.17 
dotnet add package MySql.EntityFrameworkCore --version 5.0.17 





















CREATE TABLE users (userid int NOT NULL AUTO_INCREMENT, username varchar(50) NOT NULL, course varchar(50) NOT NULL, courseDate date NOT NULL, PRIMARY KEY (userid));
INSERT INTO users VALUES(50, "Shivam Sakore", "PG-DAC", "2020-01-01");
INSERT INTO users (username, course, courseDate) VALUES ('Shyam Karhale', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Rushikesh Pise', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Rahul Singh', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Ashneer Grover', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Narendra Modi', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Piyush Bansal', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Rahul Gandhi', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Sonia Gandhi', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Narendra Singh Tomar', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Rahul Dravid', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Sachin Tendulkar', 'PG-DBDA', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Virat Kohli', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Rohit Sharma', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('MS Dhoni', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Hardik Pandya', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Ravindra Jadeja', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Kedar Jadhav', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Ravichandran Ashwin', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Jasprit Bumrah', 'PG-DAC', '2020-01-01');
INSERT INTO users (username, course, courseDate) VALUES ('Mohammed Shami', 'PG-DAC', '2020-01-01');
