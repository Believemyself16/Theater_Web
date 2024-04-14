<template>
  <div>
    <div class="d-flex justify-center black white--text" height="10">
      <!-- thẻ đen để đăng nhập/đăng ký -->
      <div class="d-flex inner justify-end align-center">
        <a class="link" href="">Đăng nhập</a>
        <span class="mx-2 pb-1">|</span>
        <a class="link" href="">Đăng ký</a>
        <a href="">
          <v-img
            height="15"
            max-width="24"
            src="@/assets/union-jack-26119_1280.png"
            class="mx-2"
          >
          </v-img>
        </a>
        <!-- nút đổi ngôn ngữ -->
        <v-button></v-button>
      </div>
    </div>
    <!-- thanh menu điều hướng -->
    <v-toolbar app height="74">
      <a href="/">
        <v-img src="https://betacinemas.vn/Assets/Common/logo/logo.png"></v-img>
      </a>
      <v-toolbar-items>
        <v-btn class="font-oswald" v-for="item in menuItems" :key="item.title">
          {{ item.title }}
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      menuItems: [
        { title: "Lịch chiếu theo rạp", route: "/lich-chieu-theo-rap" },
        { title: "Phim", route: "/phim" },
        { title: "Rạp", route: "/rap" },
        { title: "Giá vé", route: "/gia-ve" },
        { title: "Tin mới và ưu đãi", route: "/tin-moi-va-uu-dai" },
        { title: "Nhượng quyền", route: "/nhuong-quyen" },
        { title: "Thành viên", route: "/thanh-vien" },
      ],
    };
  },
};
</script>

<style scoped>
.v-application a {
  color: black !important;
}
.inner {
  width: 94%;
  max-width: 96%;
  height: 25px;
}
.link {
  text-decoration: none;
  color: white;
  font-size: 13px;
}
.link:hover {
  text-decoration: underline;
}
.font-oswald {
  font-family: "Oswald", sans-serif;
  font-weight: 700;
  font-size: 18px;
}
</style>
