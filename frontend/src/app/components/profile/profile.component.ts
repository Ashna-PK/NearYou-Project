import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterOutlet} from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { ShopService } from '../../Services/shop.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [FormsModule,HeaderComponent,CommonModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userid:any
  role:any 
  ProfileName:any 
  ngOnInit(): void {
    this.role=localStorage.getItem('role')
    if(this.role==='user')
    this.userid = localStorage.getItem('userId')
    else if(this.role==='seller')
    this.userid = localStorage.getItem("sellerId")
    this.getDetails(this.userid)
    console.log(this.userid)
  }
  constructor(private userService:UserService,
    private toastr:ToastrService,private shopService:ShopService){} //private toastr:ToastrService
  
  UserObj: any = {
    name: "",
    email: "",
    phone: "",
    address: "",
  }
  isEditingProfile=false
  http = inject(HttpClient)

  getDetails(id: string) {
    if(this.role=='user')
    {this.userService.getUserById(id).subscribe((res: any) => {
      console.log(res)
      if(res){
        this.UserObj=res
        console.log(this.UserObj)
      }
      
    })
  }
  else if(this.role=='seller')
  {
    this.shopService.getShopById(id).subscribe((res: any) => {
      console.log(res)
      if(res){
        this.UserObj=res
        console.log(this.UserObj)
      }
      
    })
  }
  }
  cancelProfileEdit(){this.isEditingProfile=false}
  enableProfileEdit(){this.isEditingProfile=true}
  onProfileSubmit() {
  this.userService. updateUserProfile(this.userid,this.UserObj).subscribe((res:any)=>{
    console.log(res)
    if (res) {
      // this.toastr.success("Successfully updated details")
      this.toastr.success('user updated')
    }
    this.isEditingProfile=false
  })
  }
  onLogOut(){
    localStorage.clear()
  }
}