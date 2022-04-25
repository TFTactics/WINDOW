﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADO.NET
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QuanLyBanHang")]
	public partial class QuanLyBanHangDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNhanVien(NhanVien instance);
    partial void UpdateNhanVien(NhanVien instance);
    partial void DeleteNhanVien(NhanVien instance);
    partial void InsertSanPham(SanPham instance);
    partial void UpdateSanPham(SanPham instance);
    partial void DeleteSanPham(SanPham instance);
    partial void InsertChiTietHoaDon(ChiTietHoaDon instance);
    partial void UpdateChiTietHoaDon(ChiTietHoaDon instance);
    partial void DeleteChiTietHoaDon(ChiTietHoaDon instance);
    partial void InsertHoaDon(HoaDon instance);
    partial void UpdateHoaDon(HoaDon instance);
    partial void DeleteHoaDon(HoaDon instance);
    partial void InsertThanhPho(ThanhPho instance);
    partial void UpdateThanhPho(ThanhPho instance);
    partial void DeleteThanhPho(ThanhPho instance);
    partial void InsertKhachHang(KhachHang instance);
    partial void UpdateKhachHang(KhachHang instance);
    partial void DeleteKhachHang(KhachHang instance);
    partial void InsertDangNhap(DangNhap instance);
    partial void UpdateDangNhap(DangNhap instance);
    partial void DeleteDangNhap(DangNhap instance);
    #endregion
		
		public QuanLyBanHangDataContext() : 
				base(global::ADO.NET.Properties.Settings.Default.QuanLyBanHangConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyBanHangDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyBanHangDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyBanHangDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyBanHangDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<NhanVien> NhanViens
		{
			get
			{
				return this.GetTable<NhanVien>();
			}
		}
		
		public System.Data.Linq.Table<SanPham> SanPhams
		{
			get
			{
				return this.GetTable<SanPham>();
			}
		}
		
		public System.Data.Linq.Table<ChiTietHoaDon> ChiTietHoaDons
		{
			get
			{
				return this.GetTable<ChiTietHoaDon>();
			}
		}
		
		public System.Data.Linq.Table<HoaDon> HoaDons
		{
			get
			{
				return this.GetTable<HoaDon>();
			}
		}
		
		public System.Data.Linq.Table<ThanhPho> ThanhPhos
		{
			get
			{
				return this.GetTable<ThanhPho>();
			}
		}
		
		public System.Data.Linq.Table<KhachHang> KhachHangs
		{
			get
			{
				return this.GetTable<KhachHang>();
			}
		}
		
		public System.Data.Linq.Table<DangNhap> DangNhaps
		{
			get
			{
				return this.GetTable<DangNhap>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NhanVien")]
	public partial class NhanVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaNV;
		
		private string _Ho;
		
		private string _Ten;
		
		private System.Nullable<bool> _Nu;
		
		private System.Nullable<System.DateTime> _NgayNV;
		
		private string _DiaChi;
		
		private string _DienThoai;
		
		private string _Hinh;
		
		private EntitySet<HoaDon> _HoaDons;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnHoChanging(string value);
    partial void OnHoChanged();
    partial void OnTenChanging(string value);
    partial void OnTenChanged();
    partial void OnNuChanging(System.Nullable<bool> value);
    partial void OnNuChanged();
    partial void OnNgayNVChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayNVChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnDienThoaiChanging(string value);
    partial void OnDienThoaiChanged();
    partial void OnHinhChanging(string value);
    partial void OnHinhChanged();
    #endregion
		
		public NhanVien()
		{
			this._HoaDons = new EntitySet<HoaDon>(new Action<HoaDon>(this.attach_HoaDons), new Action<HoaDon>(this.detach_HoaDons));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ho", DbType="NVarChar(50)")]
		public string Ho
		{
			get
			{
				return this._Ho;
			}
			set
			{
				if ((this._Ho != value))
				{
					this.OnHoChanging(value);
					this.SendPropertyChanging();
					this._Ho = value;
					this.SendPropertyChanged("Ho");
					this.OnHoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(50)")]
		public string Ten
		{
			get
			{
				return this._Ten;
			}
			set
			{
				if ((this._Ten != value))
				{
					this.OnTenChanging(value);
					this.SendPropertyChanging();
					this._Ten = value;
					this.SendPropertyChanged("Ten");
					this.OnTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nu", DbType="Bit")]
		public System.Nullable<bool> Nu
		{
			get
			{
				return this._Nu;
			}
			set
			{
				if ((this._Nu != value))
				{
					this.OnNuChanging(value);
					this.SendPropertyChanging();
					this._Nu = value;
					this.SendPropertyChanged("Nu");
					this.OnNuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayNV", DbType="Date")]
		public System.Nullable<System.DateTime> NgayNV
		{
			get
			{
				return this._NgayNV;
			}
			set
			{
				if ((this._NgayNV != value))
				{
					this.OnNgayNVChanging(value);
					this.SendPropertyChanging();
					this._NgayNV = value;
					this.SendPropertyChanged("NgayNV");
					this.OnNgayNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(50)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DienThoai", DbType="NChar(20)")]
		public string DienThoai
		{
			get
			{
				return this._DienThoai;
			}
			set
			{
				if ((this._DienThoai != value))
				{
					this.OnDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._DienThoai = value;
					this.SendPropertyChanged("DienThoai");
					this.OnDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hinh", DbType="NChar(20)")]
		public string Hinh
		{
			get
			{
				return this._Hinh;
			}
			set
			{
				if ((this._Hinh != value))
				{
					this.OnHinhChanging(value);
					this.SendPropertyChanging();
					this._Hinh = value;
					this.SendPropertyChanged("Hinh");
					this.OnHinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_HoaDon", Storage="_HoaDons", ThisKey="MaNV", OtherKey="MaNV")]
		public EntitySet<HoaDon> HoaDons
		{
			get
			{
				return this._HoaDons;
			}
			set
			{
				this._HoaDons.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = this;
		}
		
		private void detach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SanPham")]
	public partial class SanPham : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaSP;
		
		private string _TenSP;
		
		private string _DonViTinh;
		
		private System.Nullable<double> _DonGia;
		
		private string _Hinh;
		
		private EntitySet<ChiTietHoaDon> _ChiTietHoaDons;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaSPChanging(string value);
    partial void OnMaSPChanged();
    partial void OnTenSPChanging(string value);
    partial void OnTenSPChanged();
    partial void OnDonViTinhChanging(string value);
    partial void OnDonViTinhChanged();
    partial void OnDonGiaChanging(System.Nullable<double> value);
    partial void OnDonGiaChanged();
    partial void OnHinhChanging(string value);
    partial void OnHinhChanged();
    #endregion
		
		public SanPham()
		{
			this._ChiTietHoaDons = new EntitySet<ChiTietHoaDon>(new Action<ChiTietHoaDon>(this.attach_ChiTietHoaDons), new Action<ChiTietHoaDon>(this.detach_ChiTietHoaDons));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenSP", DbType="NVarChar(50)")]
		public string TenSP
		{
			get
			{
				return this._TenSP;
			}
			set
			{
				if ((this._TenSP != value))
				{
					this.OnTenSPChanging(value);
					this.SendPropertyChanging();
					this._TenSP = value;
					this.SendPropertyChanged("TenSP");
					this.OnTenSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonViTinh", DbType="NVarChar(50)")]
		public string DonViTinh
		{
			get
			{
				return this._DonViTinh;
			}
			set
			{
				if ((this._DonViTinh != value))
				{
					this.OnDonViTinhChanging(value);
					this.SendPropertyChanging();
					this._DonViTinh = value;
					this.SendPropertyChanged("DonViTinh");
					this.OnDonViTinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonGia", DbType="Float")]
		public System.Nullable<double> DonGia
		{
			get
			{
				return this._DonGia;
			}
			set
			{
				if ((this._DonGia != value))
				{
					this.OnDonGiaChanging(value);
					this.SendPropertyChanging();
					this._DonGia = value;
					this.SendPropertyChanged("DonGia");
					this.OnDonGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hinh", DbType="NChar(20)")]
		public string Hinh
		{
			get
			{
				return this._Hinh;
			}
			set
			{
				if ((this._Hinh != value))
				{
					this.OnHinhChanging(value);
					this.SendPropertyChanging();
					this._Hinh = value;
					this.SendPropertyChanged("Hinh");
					this.OnHinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SanPham_ChiTietHoaDon", Storage="_ChiTietHoaDons", ThisKey="MaSP", OtherKey="MaSP")]
		public EntitySet<ChiTietHoaDon> ChiTietHoaDons
		{
			get
			{
				return this._ChiTietHoaDons;
			}
			set
			{
				this._ChiTietHoaDons.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChiTietHoaDons(ChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.SanPham = this;
		}
		
		private void detach_ChiTietHoaDons(ChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.SanPham = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChiTietHoaDon")]
	public partial class ChiTietHoaDon : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaHD;
		
		private string _MaSP;
		
		private System.Nullable<double> _Soluong;
		
		private EntityRef<SanPham> _SanPham;
		
		private EntityRef<HoaDon> _HoaDon;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaHDChanging(string value);
    partial void OnMaHDChanged();
    partial void OnMaSPChanging(string value);
    partial void OnMaSPChanged();
    partial void OnSoluongChanging(System.Nullable<double> value);
    partial void OnSoluongChanged();
    #endregion
		
		public ChiTietHoaDon()
		{
			this._SanPham = default(EntityRef<SanPham>);
			this._HoaDon = default(EntityRef<HoaDon>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHD", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaHD
		{
			get
			{
				return this._MaHD;
			}
			set
			{
				if ((this._MaHD != value))
				{
					if (this._HoaDon.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaHDChanging(value);
					this.SendPropertyChanging();
					this._MaHD = value;
					this.SendPropertyChanged("MaHD");
					this.OnMaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					if (this._SanPham.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Soluong", DbType="Float")]
		public System.Nullable<double> Soluong
		{
			get
			{
				return this._Soluong;
			}
			set
			{
				if ((this._Soluong != value))
				{
					this.OnSoluongChanging(value);
					this.SendPropertyChanging();
					this._Soluong = value;
					this.SendPropertyChanged("Soluong");
					this.OnSoluongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SanPham_ChiTietHoaDon", Storage="_SanPham", ThisKey="MaSP", OtherKey="MaSP", IsForeignKey=true)]
		public SanPham SanPham
		{
			get
			{
				return this._SanPham.Entity;
			}
			set
			{
				SanPham previousValue = this._SanPham.Entity;
				if (((previousValue != value) 
							|| (this._SanPham.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SanPham.Entity = null;
						previousValue.ChiTietHoaDons.Remove(this);
					}
					this._SanPham.Entity = value;
					if ((value != null))
					{
						value.ChiTietHoaDons.Add(this);
						this._MaSP = value.MaSP;
					}
					else
					{
						this._MaSP = default(string);
					}
					this.SendPropertyChanged("SanPham");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HoaDon_ChiTietHoaDon", Storage="_HoaDon", ThisKey="MaHD", OtherKey="MaHD", IsForeignKey=true)]
		public HoaDon HoaDon
		{
			get
			{
				return this._HoaDon.Entity;
			}
			set
			{
				HoaDon previousValue = this._HoaDon.Entity;
				if (((previousValue != value) 
							|| (this._HoaDon.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._HoaDon.Entity = null;
						previousValue.ChiTietHoaDons.Remove(this);
					}
					this._HoaDon.Entity = value;
					if ((value != null))
					{
						value.ChiTietHoaDons.Add(this);
						this._MaHD = value.MaHD;
					}
					else
					{
						this._MaHD = default(string);
					}
					this.SendPropertyChanged("HoaDon");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HoaDon")]
	public partial class HoaDon : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaHD;
		
		private string _MaKH;
		
		private string _MaNV;
		
		private System.Nullable<System.DateTime> _NgayLapHD;
		
		private System.Nullable<System.DateTime> _NgayNhanHang;
		
		private EntitySet<ChiTietHoaDon> _ChiTietHoaDons;
		
		private EntityRef<NhanVien> _NhanVien;
		
		private EntityRef<KhachHang> _KhachHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaHDChanging(string value);
    partial void OnMaHDChanged();
    partial void OnMaKHChanging(string value);
    partial void OnMaKHChanged();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnNgayLapHDChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayLapHDChanged();
    partial void OnNgayNhanHangChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayNhanHangChanged();
    #endregion
		
		public HoaDon()
		{
			this._ChiTietHoaDons = new EntitySet<ChiTietHoaDon>(new Action<ChiTietHoaDon>(this.attach_ChiTietHoaDons), new Action<ChiTietHoaDon>(this.detach_ChiTietHoaDons));
			this._NhanVien = default(EntityRef<NhanVien>);
			this._KhachHang = default(EntityRef<KhachHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHD", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaHD
		{
			get
			{
				return this._MaHD;
			}
			set
			{
				if ((this._MaHD != value))
				{
					this.OnMaHDChanging(value);
					this.SendPropertyChanging();
					this._MaHD = value;
					this.SendPropertyChanged("MaHD");
					this.OnMaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKH", DbType="NChar(10)")]
		public string MaKH
		{
			get
			{
				return this._MaKH;
			}
			set
			{
				if ((this._MaKH != value))
				{
					if (this._KhachHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaKHChanging(value);
					this.SendPropertyChanging();
					this._MaKH = value;
					this.SendPropertyChanged("MaKH");
					this.OnMaKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="NChar(10)")]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					if (this._NhanVien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayLapHD", DbType="Date")]
		public System.Nullable<System.DateTime> NgayLapHD
		{
			get
			{
				return this._NgayLapHD;
			}
			set
			{
				if ((this._NgayLapHD != value))
				{
					this.OnNgayLapHDChanging(value);
					this.SendPropertyChanging();
					this._NgayLapHD = value;
					this.SendPropertyChanged("NgayLapHD");
					this.OnNgayLapHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayNhanHang", DbType="Date")]
		public System.Nullable<System.DateTime> NgayNhanHang
		{
			get
			{
				return this._NgayNhanHang;
			}
			set
			{
				if ((this._NgayNhanHang != value))
				{
					this.OnNgayNhanHangChanging(value);
					this.SendPropertyChanging();
					this._NgayNhanHang = value;
					this.SendPropertyChanged("NgayNhanHang");
					this.OnNgayNhanHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HoaDon_ChiTietHoaDon", Storage="_ChiTietHoaDons", ThisKey="MaHD", OtherKey="MaHD")]
		public EntitySet<ChiTietHoaDon> ChiTietHoaDons
		{
			get
			{
				return this._ChiTietHoaDons;
			}
			set
			{
				this._ChiTietHoaDons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_HoaDon", Storage="_NhanVien", ThisKey="MaNV", OtherKey="MaNV", IsForeignKey=true)]
		public NhanVien NhanVien
		{
			get
			{
				return this._NhanVien.Entity;
			}
			set
			{
				NhanVien previousValue = this._NhanVien.Entity;
				if (((previousValue != value) 
							|| (this._NhanVien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._NhanVien.Entity = null;
						previousValue.HoaDons.Remove(this);
					}
					this._NhanVien.Entity = value;
					if ((value != null))
					{
						value.HoaDons.Add(this);
						this._MaNV = value.MaNV;
					}
					else
					{
						this._MaNV = default(string);
					}
					this.SendPropertyChanged("NhanVien");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_HoaDon", Storage="_KhachHang", ThisKey="MaKH", OtherKey="MaKH", IsForeignKey=true)]
		public KhachHang KhachHang
		{
			get
			{
				return this._KhachHang.Entity;
			}
			set
			{
				KhachHang previousValue = this._KhachHang.Entity;
				if (((previousValue != value) 
							|| (this._KhachHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KhachHang.Entity = null;
						previousValue.HoaDons.Remove(this);
					}
					this._KhachHang.Entity = value;
					if ((value != null))
					{
						value.HoaDons.Add(this);
						this._MaKH = value.MaKH;
					}
					else
					{
						this._MaKH = default(string);
					}
					this.SendPropertyChanged("KhachHang");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChiTietHoaDons(ChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.HoaDon = this;
		}
		
		private void detach_ChiTietHoaDons(ChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.HoaDon = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ThanhPho")]
	public partial class ThanhPho : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ThanhPho1;
		
		private string _TenThanhPho;
		
		private EntitySet<KhachHang> _KhachHangs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnThanhPho1Changing(string value);
    partial void OnThanhPho1Changed();
    partial void OnTenThanhPhoChanging(string value);
    partial void OnTenThanhPhoChanged();
    #endregion
		
		public ThanhPho()
		{
			this._KhachHangs = new EntitySet<KhachHang>(new Action<KhachHang>(this.attach_KhachHangs), new Action<KhachHang>(this.detach_KhachHangs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="ThanhPho", Storage="_ThanhPho1", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ThanhPho1
		{
			get
			{
				return this._ThanhPho1;
			}
			set
			{
				if ((this._ThanhPho1 != value))
				{
					this.OnThanhPho1Changing(value);
					this.SendPropertyChanging();
					this._ThanhPho1 = value;
					this.SendPropertyChanged("ThanhPho1");
					this.OnThanhPho1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenThanhPho", DbType="NVarChar(50)")]
		public string TenThanhPho
		{
			get
			{
				return this._TenThanhPho;
			}
			set
			{
				if ((this._TenThanhPho != value))
				{
					this.OnTenThanhPhoChanging(value);
					this.SendPropertyChanging();
					this._TenThanhPho = value;
					this.SendPropertyChanged("TenThanhPho");
					this.OnTenThanhPhoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ThanhPho_KhachHang", Storage="_KhachHangs", ThisKey="ThanhPho1", OtherKey="ThanhPho")]
		public EntitySet<KhachHang> KhachHangs
		{
			get
			{
				return this._KhachHangs;
			}
			set
			{
				this._KhachHangs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_KhachHangs(KhachHang entity)
		{
			this.SendPropertyChanging();
			entity.ThanhPho1 = this;
		}
		
		private void detach_KhachHangs(KhachHang entity)
		{
			this.SendPropertyChanging();
			entity.ThanhPho1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KhachHang")]
	public partial class KhachHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaKH;
		
		private string _TenCty;
		
		private string _DiaChi;
		
		private string _ThanhPho;
		
		private string _DienThoai;
		
		private EntitySet<HoaDon> _HoaDons;
		
		private EntityRef<ThanhPho> _ThanhPho1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaKHChanging(string value);
    partial void OnMaKHChanged();
    partial void OnTenCtyChanging(string value);
    partial void OnTenCtyChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnThanhPhoChanging(string value);
    partial void OnThanhPhoChanged();
    partial void OnDienThoaiChanging(string value);
    partial void OnDienThoaiChanged();
    #endregion
		
		public KhachHang()
		{
			this._HoaDons = new EntitySet<HoaDon>(new Action<HoaDon>(this.attach_HoaDons), new Action<HoaDon>(this.detach_HoaDons));
			this._ThanhPho1 = default(EntityRef<ThanhPho>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKH", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaKH
		{
			get
			{
				return this._MaKH;
			}
			set
			{
				if ((this._MaKH != value))
				{
					this.OnMaKHChanging(value);
					this.SendPropertyChanging();
					this._MaKH = value;
					this.SendPropertyChanged("MaKH");
					this.OnMaKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenCty", DbType="NVarChar(50)")]
		public string TenCty
		{
			get
			{
				return this._TenCty;
			}
			set
			{
				if ((this._TenCty != value))
				{
					this.OnTenCtyChanging(value);
					this.SendPropertyChanging();
					this._TenCty = value;
					this.SendPropertyChanged("TenCty");
					this.OnTenCtyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(50)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThanhPho", DbType="NChar(10)")]
		public string ThanhPho
		{
			get
			{
				return this._ThanhPho;
			}
			set
			{
				if ((this._ThanhPho != value))
				{
					if (this._ThanhPho1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnThanhPhoChanging(value);
					this.SendPropertyChanging();
					this._ThanhPho = value;
					this.SendPropertyChanged("ThanhPho");
					this.OnThanhPhoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DienThoai", DbType="NChar(20)")]
		public string DienThoai
		{
			get
			{
				return this._DienThoai;
			}
			set
			{
				if ((this._DienThoai != value))
				{
					this.OnDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._DienThoai = value;
					this.SendPropertyChanged("DienThoai");
					this.OnDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_HoaDon", Storage="_HoaDons", ThisKey="MaKH", OtherKey="MaKH")]
		public EntitySet<HoaDon> HoaDons
		{
			get
			{
				return this._HoaDons;
			}
			set
			{
				this._HoaDons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ThanhPho_KhachHang", Storage="_ThanhPho1", ThisKey="ThanhPho", OtherKey="ThanhPho1", IsForeignKey=true)]
		public ThanhPho ThanhPho1
		{
			get
			{
				return this._ThanhPho1.Entity;
			}
			set
			{
				ThanhPho previousValue = this._ThanhPho1.Entity;
				if (((previousValue != value) 
							|| (this._ThanhPho1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ThanhPho1.Entity = null;
						previousValue.KhachHangs.Remove(this);
					}
					this._ThanhPho1.Entity = value;
					if ((value != null))
					{
						value.KhachHangs.Add(this);
						this._ThanhPho = value.ThanhPho1;
					}
					else
					{
						this._ThanhPho = default(string);
					}
					this.SendPropertyChanged("ThanhPho1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = this;
		}
		
		private void detach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DangNhap")]
	public partial class DangNhap : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private string _Password;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    #endregion
		
		public DangNhap()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591