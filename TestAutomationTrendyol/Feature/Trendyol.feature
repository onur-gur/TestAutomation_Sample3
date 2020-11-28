Feature: Trendyol
	trendyol sitesine gidilir login olunur, tüm butik imajları kontrol edilir 
	yüklenmeyen butik imajı log'a yazdırılır, rastgele butiğe gidilerek ürün detayından sepete eklenir 


Background: 
	* 'Chrome' browser açlır

Scenario: LoginAndAddTheProductToBasket
	* 'https://www.trendyol.com/' sitesine gidilir
	* Pop kapatılır
	* Giriş Yap butonuna tıklanır
	* Email adresi 'test@email.com' girilir
	* Şifre 'test_password' girilir
	* Giriş Yap butonuna tıklanır ve login olunur
	* Gelen Popup kapatılır
	* Kategorilere tıklanarak butiklerin yüklendiği kontrol edilir
	* Rastgele kategorilere tıklanır
	* Rastgele butiğe tıklanarak ürünlerin görselleri kontrol edilir
	* Rastgele ürüne tıklanır
	* Ürün sepete eklenir
 