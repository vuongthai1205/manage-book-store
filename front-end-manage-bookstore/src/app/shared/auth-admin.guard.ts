import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

export const authAdminGuard: CanActivateFn = (route, state) => {
  const userStr = localStorage.getItem('user');
  if (userStr !== null) {
    const user = JSON.parse(userStr);
    if (user && (user.roleId === 1 || user.roleId === 3)) {
      return true;
    }
  }
  
  inject(ToastrService).error('Vui lòng đăng nhập để thực hiện chức năng','Thông báo' );
  inject(Router).navigate(['login']);
  return false;
};


