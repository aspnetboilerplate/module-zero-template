//####################################################################################################
//This file was created automatically with the help of TypeScriptGenerator class.
//####################################################################################################
interface AbpErrorResponse {
	code: number;
	details;
	message: string;
	validationErrros;
}

interface AbpResult<TAnswer> {
	success:(callback: (result: TAnswer) => void) => AbpResult<TAnswer>;
	error:(callback: (response: AbpErrorResponse) => void) => AbpResult<TAnswer>;
}

interface AbpResultVoid {
	success:(callback: () => void) => AbpResultVoid;
	error:(callback: (response: AbpErrorResponse) => void) => AbpResultVoid;
}

interface ListResultDto<T> {
	items: Array<T>;
}

//####################################################################################################
//SessionAppService-----------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
interface UserLoginInfoDto {
	name: string;
	surname: string;
	userName: string;
	emailAddress: string;
	id: number;
}

interface TenantLoginInfoDto {
	tenancyName: string;
	name: string;
	id: number;
}

interface GetCurrentLoginInformationsOutput {
	user: UserLoginInfoDto;
	tenant: TenantLoginInfoDto;
}

interface SessionAppService {
	getCurrentLoginInformations(ajaxParams?: JQueryAjaxSettings): AbpResult<GetCurrentLoginInformationsOutput>;
}
//####################################################################################################


//####################################################################################################
//UserAppService--------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
interface ProhibitPermissionInput {
	userId: number;
	permissionName: string;
}

interface UserListDto {
	name: string;
	surname: string;
	userName: string;
	fullName: string;
	emailAddress: string;
	isEmailConfirmed: boolean;
	lastLoginTime: any;
	isActive: boolean;
	creationTime: any;
	id: number;
}

interface CreateUserInput {
	userName: string;
	name: string;
	surname: string;
	emailAddress: string;
	password: string;
	isActive: boolean;
}

interface UserAppService {
	prohibitPermission(input: ProhibitPermissionInput, ajaxParams?: JQueryAjaxSettings): AbpResultVoid;
	removeFromRole(userId: number, roleName: string, ajaxParams?: JQueryAjaxSettings): AbpResultVoid;
	getUsers(ajaxParams?: JQueryAjaxSettings): AbpResult<ListResultDto<UserListDto>>;
	createUser(input: CreateUserInput, ajaxParams?: JQueryAjaxSettings): AbpResultVoid;
}
//####################################################################################################


//####################################################################################################
//RoleAppService--------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
interface UpdateRolePermissionsInput {
	roleId: number;
	grantedPermissionNames: Array<string>;
}

interface RoleAppService {
	updateRolePermissions(input: UpdateRolePermissionsInput, ajaxParams?: JQueryAjaxSettings): AbpResultVoid;
}
//####################################################################################################


//####################################################################################################
//TenantAppService------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
interface TenantListDto {
	tenancyName: string;
	name: string;
	id: number;
}

interface CreateTenantInput {
	tenancyName: string;
	name: string;
	adminEmailAddress: string;
	connectionString: string;
}

interface TenantAppService {
	getTenants(ajaxParams?: JQueryAjaxSettings): AbpResult<ListResultDto<TenantListDto>>;
	createTenant(input: CreateTenantInput, ajaxParams?: JQueryAjaxSettings): AbpResultVoid;
}
//####################################################################################################


