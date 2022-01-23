var addRippleEffect = (press) => {
  const target2 = press.target;
  const rect = target2.getBoundingClientRect();
  let ripple = target2.querySelector('.ripple');
	if (!ripple) {
		ripple = document.createElement('span');
		ripple.className = 'ripple';
		ripple.style.height = ripple.style.width = Math.max(press.target.offsetWidth, target2.offsetHeight) + 'px';
		target2.appendChild(ripple);
	}
	ripple.classList.remove('show');
  const top = press.pageY - rect.top - ripple.offsetHeight / 2 - document.body.scrollTop;
  const left = press.pageX - rect.left - ripple.offsetWidth / 2 - document.body.scrollLeft;
	ripple.style.top = top + 'px';
	ripple.style.left = left + 'px';
	ripple.classList.add('show');
	return false;
}

function findButtons() {
  const buttons = document.getElementsByTagName("button");
  for (const button of buttons) {
    button.addEventListener('click', addRippleEffect, false);
  }
}

