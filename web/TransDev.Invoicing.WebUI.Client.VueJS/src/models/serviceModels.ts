//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

export class AuthenticationClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return System User Authentication. Response includes a JWT token to authorize future requests.
     */
    authenticate(query: AuthenticateUserQuery): Promise<AuthenticateUserQuery> {
        let url_ = this.baseUrl + "/api/Authentication/Authenticate";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(query);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAuthenticate(_response);
        });
    }

    protected processAuthenticate(response: Response): Promise<AuthenticateUserQuery> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = AuthenticateUserQuery.fromJS(resultData200);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = SerializableException.fromJS(resultData400);
            return throwException("User not authorized. Returns exception details.", status, _responseText, _headers, result400);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<AuthenticateUserQuery>(null as any);
    }
}

export class ClientClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return List of Active Clients
     */
    get(): Promise<GetActiveClientsResponse> {
        let url_ = this.baseUrl + "/api/Client";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: Response): Promise<GetActiveClientsResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GetActiveClientsResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = SerializableException.fromJS(resultData400);
            return throwException("Error was thrown", status, _responseText, _headers, result400);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GetActiveClientsResponse>(null as any);
    }
}

export class ItemClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Item successfully Created in the System
     */
    createItem(command: CreateItemCommand): Promise<CreateItemResponse> {
        let url_ = this.baseUrl + "/api/Item/CreateItem";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processCreateItem(_response);
        });
    }

    protected processCreateItem(response: Response): Promise<CreateItemResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = CreateItemResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = SerializableException.fromJS(resultData400);
            return throwException("Error was thrown", status, _responseText, _headers, result400);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CreateItemResponse>(null as any);
    }

    /**
     * @return Active Item List Lookup
     */
    searchActiveItems(query: GetActiveItemsQuery): Promise<GetActiveItemsResponse> {
        let url_ = this.baseUrl + "/api/Item/SearchActiveItems";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(query);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processSearchActiveItems(_response);
        });
    }

    protected processSearchActiveItems(response: Response): Promise<GetActiveItemsResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GetActiveItemsResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = SerializableException.fromJS(resultData400);
            return throwException("Error was thrown", status, _responseText, _headers, result400);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GetActiveItemsResponse>(null as any);
    }

    /**
     * @return Get Item History by Code or Id
     */
    getItemHistory(query: GetItemHistoryQuery): Promise<GetActiveItemsResponse> {
        let url_ = this.baseUrl + "/api/Item/GetItemHistory";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(query);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetItemHistory(_response);
        });
    }

    protected processGetItemHistory(response: Response): Promise<GetActiveItemsResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GetActiveItemsResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = SerializableException.fromJS(resultData400);
            return throwException("Error was thrown", status, _responseText, _headers, result400);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GetActiveItemsResponse>(null as any);
    }

    /**
     * @return Get Item History by Code or Id
     */
    deleteItemById(itemId: number): Promise<boolean> {
        let url_ = this.baseUrl + "/api/Item/DeleteItemById";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(itemId);

        let options_: RequestInit = {
            body: content_,
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDeleteItemById(_response);
        });
    }

    protected processDeleteItemById(response: Response): Promise<boolean> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = SerializableException.fromJS(resultData400);
            return throwException("Error was thrown", status, _responseText, _headers, result400);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<boolean>(null as any);
    }
}

export class AuthenticateUserQuery implements IAuthenticateUserQuery {
    username?: string | null;
    password?: string | null;

    constructor(data?: IAuthenticateUserQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.username = _data["username"] !== undefined ? _data["username"] : <any>null;
            this.password = _data["password"] !== undefined ? _data["password"] : <any>null;
        }
    }

    static fromJS(data: any): AuthenticateUserQuery {
        data = typeof data === 'object' ? data : {};
        let result = new AuthenticateUserQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["username"] = this.username !== undefined ? this.username : <any>null;
        data["password"] = this.password !== undefined ? this.password : <any>null;
        return data;
    }
}

export interface IAuthenticateUserQuery {
    username?: string | null;
    password?: string | null;
}

export class SerializableException implements ISerializableException {
    message!: string;
    stackTrace?: string | null;
    inner?: SerializableException[] | null;

    constructor(data?: ISerializableException) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.message = _data["message"] !== undefined ? _data["message"] : <any>null;
            this.stackTrace = _data["stackTrace"] !== undefined ? _data["stackTrace"] : <any>null;
            if (Array.isArray(_data["inner"])) {
                this.inner = [] as any;
                for (let item of _data["inner"])
                    this.inner!.push(SerializableException.fromJS(item));
            }
            else {
                this.inner = <any>null;
            }
        }
    }

    static fromJS(data: any): SerializableException {
        data = typeof data === 'object' ? data : {};
        let result = new SerializableException();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["message"] = this.message !== undefined ? this.message : <any>null;
        data["stackTrace"] = this.stackTrace !== undefined ? this.stackTrace : <any>null;
        if (Array.isArray(this.inner)) {
            data["inner"] = [];
            for (let item of this.inner)
                data["inner"].push(item.toJSON());
        }
        return data;
    }
}

export interface ISerializableException {
    message: string;
    stackTrace?: string | null;
    inner?: SerializableException[] | null;
}

export class ResponseBase implements IResponseBase {
    success!: boolean;
    error?: string | null;
    message?: string | null;

    constructor(data?: IResponseBase) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.success = _data["success"] !== undefined ? _data["success"] : <any>null;
            this.error = _data["error"] !== undefined ? _data["error"] : <any>null;
            this.message = _data["message"] !== undefined ? _data["message"] : <any>null;
        }
    }

    static fromJS(data: any): ResponseBase {
        data = typeof data === 'object' ? data : {};
        let result = new ResponseBase();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["success"] = this.success !== undefined ? this.success : <any>null;
        data["error"] = this.error !== undefined ? this.error : <any>null;
        data["message"] = this.message !== undefined ? this.message : <any>null;
        return data;
    }
}

export interface IResponseBase {
    success: boolean;
    error?: string | null;
    message?: string | null;
}

export class GetActiveClientsResponse extends ResponseBase implements IGetActiveClientsResponse {
    clients?: SearchClientDto[] | null;

    constructor(data?: IGetActiveClientsResponse) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            if (Array.isArray(_data["clients"])) {
                this.clients = [] as any;
                for (let item of _data["clients"])
                    this.clients!.push(SearchClientDto.fromJS(item));
            }
            else {
                this.clients = <any>null;
            }
        }
    }

    static fromJS(data: any): GetActiveClientsResponse {
        data = typeof data === 'object' ? data : {};
        let result = new GetActiveClientsResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.clients)) {
            data["clients"] = [];
            for (let item of this.clients)
                data["clients"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface IGetActiveClientsResponse extends IResponseBase {
    clients?: SearchClientDto[] | null;
}

export class SearchClientDto implements ISearchClientDto {
    name?: string | null;
    primaryContactName?: string | null;
    primaryContactEmail?: string | null;
    primaryContactPhone?: string | null;
    billingContactName?: string | null;
    billingContactEmail?: string | null;
    billingContactPhone?: string | null;

    constructor(data?: ISearchClientDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"] !== undefined ? _data["name"] : <any>null;
            this.primaryContactName = _data["primaryContactName"] !== undefined ? _data["primaryContactName"] : <any>null;
            this.primaryContactEmail = _data["primaryContactEmail"] !== undefined ? _data["primaryContactEmail"] : <any>null;
            this.primaryContactPhone = _data["primaryContactPhone"] !== undefined ? _data["primaryContactPhone"] : <any>null;
            this.billingContactName = _data["billingContactName"] !== undefined ? _data["billingContactName"] : <any>null;
            this.billingContactEmail = _data["billingContactEmail"] !== undefined ? _data["billingContactEmail"] : <any>null;
            this.billingContactPhone = _data["billingContactPhone"] !== undefined ? _data["billingContactPhone"] : <any>null;
        }
    }

    static fromJS(data: any): SearchClientDto {
        data = typeof data === 'object' ? data : {};
        let result = new SearchClientDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name !== undefined ? this.name : <any>null;
        data["primaryContactName"] = this.primaryContactName !== undefined ? this.primaryContactName : <any>null;
        data["primaryContactEmail"] = this.primaryContactEmail !== undefined ? this.primaryContactEmail : <any>null;
        data["primaryContactPhone"] = this.primaryContactPhone !== undefined ? this.primaryContactPhone : <any>null;
        data["billingContactName"] = this.billingContactName !== undefined ? this.billingContactName : <any>null;
        data["billingContactEmail"] = this.billingContactEmail !== undefined ? this.billingContactEmail : <any>null;
        data["billingContactPhone"] = this.billingContactPhone !== undefined ? this.billingContactPhone : <any>null;
        return data;
    }
}

export interface ISearchClientDto {
    name?: string | null;
    primaryContactName?: string | null;
    primaryContactEmail?: string | null;
    primaryContactPhone?: string | null;
    billingContactName?: string | null;
    billingContactEmail?: string | null;
    billingContactPhone?: string | null;
}

export class CreateItemResponse extends ResponseBase implements ICreateItemResponse {

    constructor(data?: ICreateItemResponse) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
    }

    static fromJS(data: any): CreateItemResponse {
        data = typeof data === 'object' ? data : {};
        let result = new CreateItemResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        super.toJSON(data);
        return data;
    }
}

export interface ICreateItemResponse extends IResponseBase {
}

export class CreateItemCommand implements ICreateItemCommand {
    item?: ItemDto | null;

    constructor(data?: ICreateItemCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.item = _data["item"] ? ItemDto.fromJS(_data["item"]) : <any>null;
        }
    }

    static fromJS(data: any): CreateItemCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateItemCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["item"] = this.item ? this.item.toJSON() : <any>null;
        return data;
    }
}

export interface ICreateItemCommand {
    item?: ItemDto | null;
}

export class ItemDto implements IItemDto {
    id!: number;
    code?: string | null;
    type!: ItemType;
    description?: string | null;
    price!: number;

    constructor(data?: IItemDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"] !== undefined ? _data["id"] : <any>null;
            this.code = _data["code"] !== undefined ? _data["code"] : <any>null;
            this.type = _data["type"] !== undefined ? _data["type"] : <any>null;
            this.description = _data["description"] !== undefined ? _data["description"] : <any>null;
            this.price = _data["price"] !== undefined ? _data["price"] : <any>null;
        }
    }

    static fromJS(data: any): ItemDto {
        data = typeof data === 'object' ? data : {};
        let result = new ItemDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id !== undefined ? this.id : <any>null;
        data["code"] = this.code !== undefined ? this.code : <any>null;
        data["type"] = this.type !== undefined ? this.type : <any>null;
        data["description"] = this.description !== undefined ? this.description : <any>null;
        data["price"] = this.price !== undefined ? this.price : <any>null;
        return data;
    }
}

export interface IItemDto {
    id: number;
    code?: string | null;
    type: ItemType;
    description?: string | null;
    price: number;
}

/** 0 = Labor */
export enum ItemType {
    Labor = 0,
}

export class GetActiveItemsResponse extends ResponseBase implements IGetActiveItemsResponse {
    items!: ItemDto[];

    constructor(data?: IGetActiveItemsResponse) {
        super(data);
        if (!data) {
            this.items = [];
        }
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(ItemDto.fromJS(item));
            }
            else {
                this.items = <any>null;
            }
        }
    }

    static fromJS(data: any): GetActiveItemsResponse {
        data = typeof data === 'object' ? data : {};
        let result = new GetActiveItemsResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface IGetActiveItemsResponse extends IResponseBase {
    items: ItemDto[];
}

export class GetActiveItemsQuery implements IGetActiveItemsQuery {
    searchQuery?: string | null;
    pageSize!: number;
    page!: number;

    constructor(data?: IGetActiveItemsQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.searchQuery = _data["searchQuery"] !== undefined ? _data["searchQuery"] : <any>null;
            this.pageSize = _data["pageSize"] !== undefined ? _data["pageSize"] : <any>null;
            this.page = _data["page"] !== undefined ? _data["page"] : <any>null;
        }
    }

    static fromJS(data: any): GetActiveItemsQuery {
        data = typeof data === 'object' ? data : {};
        let result = new GetActiveItemsQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["searchQuery"] = this.searchQuery !== undefined ? this.searchQuery : <any>null;
        data["pageSize"] = this.pageSize !== undefined ? this.pageSize : <any>null;
        data["page"] = this.page !== undefined ? this.page : <any>null;
        return data;
    }
}

export interface IGetActiveItemsQuery {
    searchQuery?: string | null;
    pageSize: number;
    page: number;
}

export class GetItemHistoryQuery implements IGetItemHistoryQuery {
    code?: string | null;
    id?: number | null;

    constructor(data?: IGetItemHistoryQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.code = _data["code"] !== undefined ? _data["code"] : <any>null;
            this.id = _data["id"] !== undefined ? _data["id"] : <any>null;
        }
    }

    static fromJS(data: any): GetItemHistoryQuery {
        data = typeof data === 'object' ? data : {};
        let result = new GetItemHistoryQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["code"] = this.code !== undefined ? this.code : <any>null;
        data["id"] = this.id !== undefined ? this.id : <any>null;
        return data;
    }
}

export interface IGetItemHistoryQuery {
    code?: string | null;
    id?: number | null;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}