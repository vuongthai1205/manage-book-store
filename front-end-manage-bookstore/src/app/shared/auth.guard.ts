import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  if (localStorage.getItem('token') !== null) {
    return true;
  } else {
    inject(ToastrService).error('Vui lòng đăng nhập để thực hiện chức năng','Thông báo' );
    inject(Router).navigate(['login']);
    return false;
  }
};
