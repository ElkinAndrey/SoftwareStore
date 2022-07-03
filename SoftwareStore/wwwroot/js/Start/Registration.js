function leftright1() {
	var b = document.querySelector("#Password");
	b.setAttribute("type", "text");
	var c = document.querySelector("#ShowPasswordButton");
	c.setAttribute("style", "background-color: #57c49e;");
	c.setAttribute("onclick", "leftright2()");
}
function leftright2() {

	var b = document.querySelector("#Password");
	b.setAttribute("type", "password");
	var c = document.querySelector("#ShowPasswordButton");
	c.setAttribute("style", "background-color: #eaeaea;");
	c.setAttribute("onclick", "leftright1()");
}