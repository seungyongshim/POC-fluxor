var i = 0;

var addRippleEffect = function (press) {
	var target = press.target;
	if (target.tagName.toLowerCase() !== 'button') return false;
	var rect = target.getBoundingClientRect();
	var ripple = target.querySelector('.ripple');
	if (!ripple) {
		ripple = document.createElement('span');
		ripple.className = 'ripple';
		ripple.style.height = ripple.style.width = Math.max(press.target.offsetWidth, target.offsetHeight) + 'px';
		target.appendChild(ripple);
    }
	var top = press.pageY - rect.top - ripple.offsetHeight / 2 - document.body.scrollTop;
	var left = press.pageX - rect.left - ripple.offsetWidth / 2 - document.body.scrollLeft;
	ripple.style.top = top + 'px';
	ripple.style.left = left + 'px';
    ripple.classList.add('show');
  ripple.tagName= 'rippl' + i++;
  
	return false;
}

document.addEventListener('click', addRippleEffect, false);
