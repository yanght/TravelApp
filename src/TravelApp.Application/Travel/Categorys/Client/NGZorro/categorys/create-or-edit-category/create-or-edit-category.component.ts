
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateCategoryInput,CategoryEditDto, CategoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-category',
  templateUrl: './create-or-edit-category.component.html',
  styleUrls:[
	'create-or-edit-category.component.less'
  ],
})

export class CreateOrEditCategoryComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: CategoryEditDto=new CategoryEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _categoryService: CategoryServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._categoryService.getForEdit(this.id).subscribe(result => {
			this.entity = result.category;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateCategoryInput();
		input.category = this.entity;

		this.saving = true;

		this._categoryService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
