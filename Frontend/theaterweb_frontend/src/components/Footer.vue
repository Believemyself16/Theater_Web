<template>
  <v-container class="bg-color pb-16" fluid>
    <hr />
    <v-row class="mt-2">
      <v-col cols="1"></v-col>
      <v-col cols="2" xl="3">
        <a href="/">
          <v-img
            class="ma-2"
            :width="150"
            src="https://betacinemas.vn/Assets/Common/logo/logo.png"
          ></v-img>
        </a>
        <ul class="font-oswald custom-list-style-type">
          <li v-for="item in about" :key="item.tab">
            <a :href="item.route">
              <v-icon>mdi-chevron-right</v-icon>
              {{ item.tab }}
            </a>
          </li>
        </ul>
      </v-col>
      <v-col cols="4" xl="4">
        <!-- thẻ div d-flex để thu ngắn chiều dài thẻ <p> -->
        <div class="d-flex">
          <p class="title-block font-weight-black font-oswald">CỤM RẠP BETA</p>
        </div>
        <div>
          <ul class="font-oswald custom-list-style-type">
            <li v-for="item in theaterBranchs" :key="item.branch">
              <a :href="item.route">
                <v-icon>mdi-chevron-right</v-icon>
                Beta Cinemas {{ item.branch }}
              </a>
            </li>
            <li>
              <a href="">
                <v-icon>mdi-chevron-right</v-icon>
                Tải Ứng Dụng Beta Cinemas
              </a>
            </li>
          </ul>
        </div>
      </v-col>
      <v-col cols="2">
        <div class="d-flex">
          <p class="title-block font-weight-black font-oswald">
            KẾT NỐI VỚI CHÚNG TÔI
          </p>
        </div>
        <div class="d-flex custom-list-style-type">
          <v-row>
            <v-col
              cols="2"
              xl="2"
              v-for="(item, index) in socialItems"
              :key="index"
            >
              <a :href="item.route">
                <v-img
                  :width="30"
                  :src="item.src"
                  @mouseenter="showHoverImage(index)"
                  @mouseleave="hideHoverImage(index)"
                >
                </v-img>
              </a>
            </v-col>
          </v-row>
        </div>
        <v-img class="mt-3" src="@/assets/dathongbao.png" :width="175"></v-img>
      </v-col>
      <v-col cols="2">
        <div class="d-flex">
          <p class="title-block font-weight-black font-oswald">LIÊN HỆ</p>
        </div>
        <div class="font-oswald">
          <p style="font-size: 17px" class="font-weight-medium">
            CÔNG TY CỔ PHẦN BETA MEDIA
          </p>
          <p>
            Giấy chứng nhận ĐKKD số: 0106633482 - Đăng ký lần đầu ngày
            08/09/2014 tại Sở Kế hoạch và Đầu tư Thành phố Hà Nội
          </p>
          <p>
            Địa chỉ trụ sở: Tầng 3, số 595, đường Giải Phóng, phường Giáp Bát,
            quận Hoàng Mai, thành phố Hà Nội
          </p>
          <p>Hotline: 1900 636807 / 0934632682</p>
          <p>Email: mkt@betacinemas.vn</p>
          <p style="font-size: 17px" class="font-weight-bold">
            Liên hệ hợp tác kinh doanh:
          </p>
          <p style="font-size: 17px">Email: bachtx@betagroup.vn</p>
        </div>
      </v-col>
      <v-col cols="1"></v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "Footer",
  data() {
    return {
      about: [
        { tab: "Giới thiệu", route: "" },
        { tab: "Tuyển dụng", route: "" },
        { tab: "Liên hệ", route: "" },
        { tab: "F.A.Q", route: "" },
        { tab: "Hoạt động xã hội", route: "" },
        { tab: "Điều khoản sử dụng", route: "" },
        { tab: "Chính sách thanh toán, đổi trả - hoàn vé", route: "" },
        { tab: "Liên hệ quảng cáo", route: "" },
        { tab: "Điều khoản bảo mật", route: "" },
        { tab: "Hướng dẫn đặt vé online", route: "" },
      ],
      theaterBranchs: [
        { branch: "Ung Văn Khiêm - Sắp khai trương", route: "" },
        { branch: "Lào Cai - Hotline 0358 968 970", route: "" },
        {
          branch: "Trần Quang Khải, TP Hồ Chí Minh - Hotline 1900 638 362",
          route: "",
        },
        {
          branch: "TRMall Phú Quốc, Kiên Giang - Hotline 0983 474 440",
          route: "",
        },
        {
          branch: "Empire Bình Dương - Hotline 0934 573 748",
          route: "",
        },
        {
          branch: "Quang Trung, TP Hồ Chí Minh - Hotline 0706 075 509",
          route: "",
        },
        { branch: "Giải Phóng, Hà Nội -  Hotline 0585 680 360", route: "" },
        { branch: "Thanh Xuân, Hà Nội - Hotline 082 4812878", route: "" },
        { branch: "Mỹ Đình, Hà Nội - Hotline 0866 493 413", route: "" },
        { branch: "Đan Phượng, Hà Nội - Hotline 0983 901 714", route: "" },
        { branch: "Thái Nguyên - Hotline 0867 460 053", route: "" },
        { branch: "Thanh Hóa - Hotline 0325 360 249", route: "" },
        { branch: "Bắc Giang - Hotline 0866 493 413", route: "" },
        { branch: "Nha Trang, Khánh Hòa - Hotline 0399 475 165", route: "" },
        { branch: "Biên Hòa, Đồng Nai - Hotline 0979 460 002", route: "" },
        { branch: "Long Khánh, Đồng Nai - Hotline 0925 165 684", route: "" },
        { branch: "Phú Mỹ, Bà Rịa Vũng Tàu - Hotline 0886 006 310", route: "" },
        {
          branch: "Hồ Tràm, Bà Rịa Vũng Tàu - Hotline 0254 3788601",
          route: "",
        },
        { branch: "Tân Uyên, Bình Dương - Hotline 0937 905 925", route: "" },
      ],
      // ảnh phải có dòng require
      socialItems: [
        { src: require("@/assets/Social/facebook.png") },
        { src: require("@/assets/Social/youtube.png") },
        { src: require("@/assets/Social/tiktok.png") },
        { src: require("@/assets/Social/instagram.png") },
      ],
      hoverSocialItem: [
        {
          src: require("@/assets/Social/facebook_colored.png"),
          visible: false,
          route: "https://www.facebook.com/betacinemas/",
        },
        {
          src: require("@/assets/Social/youtube_colored.png"),
          visible: false,
          route: "https://www.youtube.com/channel/UCGj6uah35-eNiH_2mdubYRw/",
        },
        {
          src: require("@/assets/Social/tiktok_colored.png"),
          visible: false,
          route: "https://www.tiktok.com/@beta_cinemas/",
        },
        {
          src: require("@/assets/Social/instagram_colored.png"),
          visible: false,
          route: "https://www.instagram.com/betacinemas/",
        },
      ],
    };
  },
  methods: {
    showHoverImage(index) {
      this.$set(this.socialItems, index, {
        ...this.hoverSocialItem[index], //dấu ... được sử dụng để truyền dữ liệu từ cha xuống con
        visible: true,
      });
    },
    hideHoverImage(index) {
      this.$set(this.socialItems, index, {
        ...this.hoverSocialItem[index],
        visible: false,
      });
    },
  },
};
</script>

<style scoped>
.bg-color {
  background-color: #f8f8f8;
}
.v-application a {
  color: black;
}
/* danh sách about và branch */
.font-oswald {
  font-family: "Oswald", sans-serif;
  font-size: 14px;
}
.custom-list-style-type {
  list-style: none;
}
a {
  text-decoration: none;
  color: black;
}
a:hover {
  text-decoration: underline;
  color: #337ab7;
}
.title-block {
  font-size: 20px;
  padding-bottom: 6px;
  border-bottom: 4px solid;
  border-image: linear-gradient(to right, #4888d7, #1d579e);
  border-image-slice: 1;
}
/* phần liên hệ */
</style>
