Feature: ApiTestCase

Background:
	* Apinin boş olduğu doğrulanır

Scenario: CheckTitleIsRequired
	* Title parametresi girilmeden kitap eklenmeye çalışılır

Scenario: CheckAuthorIsRequired
	* Author parametresi girilmeden kitap eklenmeye çalışılır

Scenario: CheckAuthorCanNotBeEmpty
	* Author parametresi  boş girilerek kitap eklenmeye çalışılır

Scenario: CheckTitleCanNotBeEmpty
	* Title parametresi boş girilerek kitap eklenmeye çalışılır

Scenario: CheckIdIsReadonlyParameter
	* Id girilerek kitap eklenmeye çalışılır

Scenario: AddBookWithCorrentFormat
	* Kitap adı 'Suç ve Ceza', yazarı 'Dostoyevski' olan kitap eklenir
	* Eklenen Suç ve Ceza kitabı idsi ile çağrılarak eklendiği görülür

Scenario: CheckExistBookCanNotAdded	
	* Kitap adı 'Savaş ve Barış', yazarı 'Tolsytoy' olan kitap eklenir
	* Kitap adı 'Savaş ve Barış', yazarı 'Tolsytoy' olan kitap tekrar eklenmediği kontrol edilir