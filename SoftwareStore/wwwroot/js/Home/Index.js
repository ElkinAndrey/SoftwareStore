function All() {
	for (var i = 0; i < document.getElementsByClassName('showAllBuy').length; i++) {
		document.getElementsByClassName('showAllBuy')[i].style.display = "block";
	}
}
function Buy() {

	for (var i = 0; i < document.getElementsByClassName('showAllBuy').length; i++) {
		document.getElementsByClassName('showAllBuy')[i].style.display = "none";
	}
}